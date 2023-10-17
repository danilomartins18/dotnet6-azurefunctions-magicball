using System;
using Microsoft.Extensions.Logging;

namespace func_magicballapp.Services;

public class MagicBallService : IMagicBallService
{
  private readonly ILogger _logger;

  public MagicBallService(ILogger logger)
  {
    _logger = logger;
  }

  private static readonly string[] defaultResponses = new[] {
            "Yes", "No", "Maybe", "Most likely", "Do not count on it", "Ask again"
        };

  public string GetResponse(string question)
  {
    _logger.LogInformation("Starting get response process...");

    if (string.IsNullOrWhiteSpace(question))
      throw new ArgumentException("You need to ask a question.");

    _logger.LogInformation($"Question asked: {question}");

    var random = new Random();
    var randomIndex = random.Next(0, defaultResponses.Length);

    return defaultResponses[randomIndex];
  }
}