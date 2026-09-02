using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049DE RID: 18910
	public interface IPanelTickInterface
	{
		// Token: 0x0603177C RID: 202620
		void Tick(float deltaTime);

		// Token: 0x0603177D RID: 202621
		void AfterTick(float deltaTime);
	}
}
