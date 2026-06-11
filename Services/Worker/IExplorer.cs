namespace Artimus.Services.Worker {
	/**
	 * A certain type of job that is sent through the corresponding
	 * Stargate and to be expected to return with the result (callback).
	 */
	public interface IExplorer {
		public void Process();

		public void Finish() { }
	}
}