using System.IO;
using System.Text.RegularExpressions;

namespace Artimus.Services {
	public static class DirectorySanitizer {
		public static string ReplaceInvalidCharacters(string filename) {
			var invalidCharacters = Regex.Escape(new string(Path.GetInvalidFileNameChars()));

			return Regex.Replace(filename, $@"[{invalidCharacters}]+", "_");
		}

		/**
		 * I don't really like this, could change any time.
		 *
		 * @see https://stackoverflow.com/questions/309485/c-sharp-sanitize-file-name
		 */
		public static string ReplaceReservedWords(string filename) {
			var reservedWordsList = new [] {
				"CON", "PRN", "AUX", "NUL",
				"COM0", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
				"LPT0", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
			};

			var reservedWords = string.Join("|", reservedWordsList);

			return Regex.Replace(
				filename.Trim(' ', '.'),
				$@"^({reservedWords})(\..*)?$",
				"_",
				RegexOptions.IgnoreCase | RegexOptions.CultureInvariant
			);
		}

		public static string CoerceValidFileName(string filename) {
			var sanitized = ReplaceInvalidCharacters(filename);
			sanitized = ReplaceReservedWords(sanitized);

			return sanitized;
		}
	}
}