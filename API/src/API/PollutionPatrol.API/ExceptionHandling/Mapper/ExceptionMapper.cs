namespace PollutionPatrol.API.ExceptionHandling.Mapper;

/// <summary>
/// Provides a mechanism to translate technical exceptions into user-friendly error messages.
/// </summary>
internal static class ExceptionMapper
{
    private const string InternalServerError = nameof(InternalServerError);

    /// <summary>
    /// An in-memory dictionary is used to store exception message templates for the following reasons:
    /// 
    /// * **Performance:** In-memory access provides extremely fast retrieval of templates, which
    ///   is essential for generating user-friendly error messages with minimal delay.
    /// * **Simplicity:**  An in-memory solution avoids the complexity and overhead of external 
    ///   dependencies like a database or caching service.
    /// * **Dataset Size:** The expected number of templates is relatively small, making in-memory 
    ///   storage completely feasible.
    /// 
    /// Note: If the volume of templates grows significantly OR a distributed system architecture 
    /// is introduced, consider using a dedicated caching solution like Redis to distribute the load 
    /// and manage template updates more efficiently.
    /// </summary>
    private static readonly Dictionary<string, List<string>> Templates = new(MessageTemplateLoader.LoadTemplates());
    
    /// <summary>
    /// Translates an exception into a user-friendly error message based on stored templates.
    /// </summary>
    /// <param name="exception">The exception to translate.</param>
    /// <returns>A user-friendly error message.</returns>
    internal static string MapExceptionToUserFriendlyMessage(Exception exception)
    {
        var exceptionName = GetExceptionName(exception);

        if (Templates.TryGetValue(exceptionName, out var templates))
        {
            var template = GetRandomTemplate(templates);
            var message = InjectValues(template, exception);
            return message;
        }
        else
        {
            // Fallback message (if no matching template is found)
            // Note: This fallback mechanism is designed for application stability. It provides a generic,
            // user-friendly message in cases where a specific template is not found. This prevents 
            // unintended exposure of internal error details while ensuring the application continues to function.
            var messages = Templates.GetValueOrDefault(key: InternalServerError)!; // At least one fallback message  
            var message = GetRandomTemplate(messages);
            return message;
        }
    }
    
    /// <summary>
    /// Extracts the simple name of the exception type (e.g., "ArgumentException").
    /// </summary>
    /// <param name="exception">The exception to analyze.</param>
    /// <returns>The name of the exception type.</returns>
    private static string GetExceptionName(Exception exception) => exception.GetType().Name;

    /// <summary>
    /// Selects a random message template from a provided list.
    /// </summary>
    /// <param name="templates">A list of possible message templates.</param>
    /// <returns>A randomly chosen template from the list.</returns>
    private static string GetRandomTemplate(IReadOnlyList<string> templates)
    {
        var randomIndex = Random.Shared.Next(0, templates.Count);
        return templates[randomIndex];
    }

    /// <summary>
    /// Injects property values from the exception object into a message template.
    /// </summary>
    /// <param name="template">The message template containing placeholders (e.g., "{ErrorCode}")</param>
    /// <param name="ex">The exception containing the property values.</param>
    /// <returns>The message template with placeholders replaced by corresponding property values.</returns>
    private static string InjectValues(string template, Exception ex)
    {
        if (!template.Contains('{') || !template.Contains('}')) return template;

        foreach (var c in template)
        {
            if (c != '{') continue;
            var startIndex = template.IndexOf(c) + 1;
            var endIndex = template.IndexOf('}', startIndex);
            var placeholder = template.Substring(startIndex, endIndex - startIndex);

            var propertyInfo = ex.GetType()
                .GetProperty(placeholder, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (propertyInfo == null) continue;
            var propertyValue = propertyInfo.GetValue(ex);
            if (propertyValue != null)
                template = template.Replace("{" + placeholder + "}", propertyValue.ToString());
        }

        return template;
    }
}