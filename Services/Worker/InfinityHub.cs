using Godot;

namespace Artimus.Services.Worker;

[GlobalClass]
public partial class InfinityHub : Node {
	public static InfinityHub instance;

	public readonly Stargate _genericStargate = new ();

	public override void _EnterTree() {
		instance = this;
	}

	public override void _Process(double delta) {
		_genericStargate.Finish();
	}

	public void EnterGenericGate(IExplorer explorer) {
		_genericStargate.Enter(explorer);
	}

	public override void _ExitTree() {
		_genericStargate.StopWorker();

		instance = null;
	}
}