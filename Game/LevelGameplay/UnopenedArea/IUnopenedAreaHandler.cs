using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.UnopenedArea
{
	// Token: 0x02006A64 RID: 27236
	[NullableContext(1)]
	public interface IUnopenedAreaHandler
	{
		// Token: 0x1700A251 RID: 41553
		// (get) Token: 0x060435FA RID: 275962
		bool ForbidVehicleOnEnter { get; }

		// Token: 0x060435FB RID: 275963
		bool OnEnter();

		// Token: 0x060435FC RID: 275964
		void OnExit();

		// Token: 0x060435FD RID: 275965
		void Tick(float delta);

		// Token: 0x060435FE RID: 275966
		void OnChangeRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle);

		// Token: 0x060435FF RID: 275967
		void Clear();
	}
}
