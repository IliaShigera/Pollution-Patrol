namespace PollutionPatrol.API.ExceptionHandling.Mapper;

internal static class MessageTemplateLoader
{
    private const string MessageTemplateFileName = "FriendlyMessageTemplates.json";

    private const string InternalServerError = nameof(InternalServerError);

    /// <summary>
    /// Loads the exception message templates from an embedded JSON resource.
    /// </summary>
    /// <returns>A dictionary of exception message templates, where the key is the exception type and the value is a list of possible messages.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the embedded resource is missing, the template data is corrupt, or deserialization fails.</exception>
    internal static Dictionary<string, List<string>> LoadTemplates()
    {
        try
        {
            var jsonData = GetTemplatesSourceData();

            var templates = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(jsonData);

            if (templates is null || templates.Count is 0)
            {
                throw new InvalidOperationException(
                    "Failed to load exception message templates. Template data is empty or missing.");
            }

            return templates;
        }
        catch (InvalidOperationException ex)
        {
            Log.Error(ex, "Error loading exception message templates: {ErrorMessage}", ex.Message);

            // Provide a fallback message
            // Even if primary template loading failed, this ensures at least one generic 
            // fallback message is available for a controlled error response.
            return new Dictionary<string, List<string>>
            {
                { InternalServerError, new List<string> { "An internal server error occurred. Please try again later." } }
            };
        }
    }

    /// <summary>
    /// Retrieves the raw JSON content of the embedded message template resource.
    /// </summary>
    /// <returns>A string containing the JSON template data.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the embedded resource cannot be found.</exception>
    private static string GetTemplatesSourceData()
    {
        var assemblyContext = typeof(ExceptionMapper).Assembly;
        var resourceName = $"{typeof(ExceptionMapper).Namespace}.{MessageTemplateFileName}";
        using var stream = assemblyContext.GetManifestResourceStream(resourceName);

        if (stream is null)
            throw new InvalidOperationException(
                $"Embedded resource '{MessageTemplateFileName}' is missing. Cannot load message templates.");

        using var reader = new StreamReader(stream);
        var jsonData = reader.ReadToEnd();
        return jsonData;
    }
}