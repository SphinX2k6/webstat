using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047F2 RID: 18418
	[NullableContext(1)]
	[Nullable(0)]
	public class DropItemData
	{
		// Token: 0x0401B67B RID: 112251
		public InventoryDefine.EItemDataType ItemType;

		// Token: 0x0401B67C RID: 112252
		public int ConfigId;

		// Token: 0x0401B67D RID: 112253
		[Nullable(2)]
		public ItemConfig Config;

		// Token: 0x0401B67E RID: 112254
		public int ItemCount;

		// Token: 0x0401B67F RID: 112255
		public int ShowPlanId;

		// Token: 0x0401B680 RID: 112256
		public EDropAdsorptionType? AdsorptionType;

		// Token: 0x0401B681 RID: 112257
		public float StartSpeed;

		// Token: 0x0401B682 RID: 112258
		public float RotationProtectTime;

		// Token: 0x0401B683 RID: 112259
		public float AdsorptionTime;

		// Token: 0x0401B684 RID: 112260
		public float AdsorptionProtectTime = 0.2f;

		// Token: 0x0401B685 RID: 112261
		public EDropStateType DropState;

		// Token: 0x0401B686 RID: 112262
		public bool MeshIsInited;

		// Token: 0x0401B687 RID: 112263
		public bool DropFinished;

		// Token: 0x0401B688 RID: 112264
		public string BornEffectPath = "";

		// Token: 0x0401B689 RID: 112265
		public string TailEffectPath = "";

		// Token: 0x0401B68A RID: 112266
		public string DestroyEffectPath = "";
	}
}
