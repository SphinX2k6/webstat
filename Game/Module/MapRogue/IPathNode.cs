using System;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005921 RID: 22817
	public interface IPathNode
	{
		// Token: 0x17009425 RID: 37925
		// (get) Token: 0x06039E8F RID: 237199
		int GridIndex { get; }

		// Token: 0x17009426 RID: 37926
		// (get) Token: 0x06039E90 RID: 237200
		int Cost { get; }

		// Token: 0x17009427 RID: 37927
		// (get) Token: 0x06039E91 RID: 237201
		bool Walkable { get; }
	}
}
