using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006ECF RID: 28367
	[NullableContext(1)]
	[Nullable(0)]
	public class DollGrabMachineItem
	{
		// Token: 0x1700A3FB RID: 41979
		// (get) Token: 0x06044BDC RID: 281564 RVA: 0x011DE2D5 File Offset: 0x011DC4D5
		// (set) Token: 0x06044BDD RID: 281565 RVA: 0x011DE2DD File Offset: 0x011DC4DD
		public int ItemId { get; set; }

		// Token: 0x1700A3FC RID: 41980
		// (get) Token: 0x06044BDE RID: 281566 RVA: 0x011DE2E6 File Offset: 0x011DC4E6
		// (set) Token: 0x06044BDF RID: 281567 RVA: 0x011DE2EE File Offset: 0x011DC4EE
		public int CategoryId { get; set; }

		// Token: 0x06044BE0 RID: 281568 RVA: 0x011DE2F8 File Offset: 0x011DC4F8
		[NullableContext(2)]
		public DollGrabMachineItem(int itemId, int categoryId, BP_DollActor_C itemActor, global::Vector relOriginLocation, Rotator relOriginRotation)
		{
			this.ItemId = itemId;
			this.CategoryId = categoryId;
			this.ItemActor = itemActor;
			if (relOriginLocation != null)
			{
				this.OriginLocation.DeepCopy(relOriginLocation);
			}
			if (relOriginRotation != null)
			{
				this.OriginRotation.DeepCopy(relOriginRotation);
			}
			DollGrabItemsCsv? config = ConfigDollGrabItemsCsvById.GetConfig(this.CategoryId, true);
			if (config != null)
			{
				this.IsTouchGet = config.Value.IsTouchGet;
				if (config.Value.AddTime > 0)
				{
					this.AddTime = new float?((float)config.Value.AddTime);
				}
				this.EndlessScore = config.Value.InfiniteModeScore;
				this.ItemBpPath = config.Value.ItemBpPath + "_C";
				this.DropId = config.Value.DropId;
			}
		}

		// Token: 0x04026493 RID: 156819
		[Nullable(2)]
		public BP_DollActor_C ItemActor;

		// Token: 0x04026494 RID: 156820
		public readonly global::Vector OriginLocation = global::Vector.Create();

		// Token: 0x04026495 RID: 156821
		public readonly Rotator OriginRotation = Rotator.Create();

		// Token: 0x04026496 RID: 156822
		public bool IsTouchGet;

		// Token: 0x04026497 RID: 156823
		public float? AddTime;

		// Token: 0x04026498 RID: 156824
		public int DropId;

		// Token: 0x04026499 RID: 156825
		public int EndlessScore;

		// Token: 0x0402649A RID: 156826
		public string ItemBpPath = "";

		// Token: 0x0402649B RID: 156827
		public bool IsEndlessStartItem;
	}
}
