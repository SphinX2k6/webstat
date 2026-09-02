using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model
{
	// Token: 0x02004AD6 RID: 19158
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class WuWaGoModel : ModelBase<WuWaGoModel>
	{
		// Token: 0x17008536 RID: 34102
		// (get) Token: 0x06031F45 RID: 204613 RVA: 0x00C820F7 File Offset: 0x00C802F7
		public WuWaGoGameData GameData
		{
			get
			{
				if (this.GameDataInner == null)
				{
					this.GameDataInner = new WuWaGoGameData();
				}
				return this.GameDataInner;
			}
		}

		// Token: 0x06031F46 RID: 204614 RVA: 0x00C82112 File Offset: 0x00C80312
		public bool InitGameData(Transform originTransform, WuWaGoConfigData levelData)
		{
			return this.GameData.Init(originTransform, levelData);
		}

		// Token: 0x06031F47 RID: 204615 RVA: 0x00C82121 File Offset: 0x00C80321
		public void ResetGameData()
		{
			WuWaGoGameData gameDataInner = this.GameDataInner;
			if (gameDataInner == null)
			{
				return;
			}
			gameDataInner.Reset();
		}

		// Token: 0x06031F48 RID: 204616 RVA: 0x00C82133 File Offset: 0x00C80333
		[return: Nullable(2)]
		public WuWaGoGrid GetGrid(Vector coordinate)
		{
			return this.GameData.GetGrid(coordinate);
		}

		// Token: 0x06031F49 RID: 204617 RVA: 0x00C82141 File Offset: 0x00C80341
		[NullableContext(2)]
		public WuWaGoGrid GetGridById(int gridId)
		{
			return this.GameData.GetGridById(gridId);
		}

		// Token: 0x06031F4A RID: 204618 RVA: 0x00C82150 File Offset: 0x00C80350
		[NullableContext(2)]
		public WuWaGoBaseUnit GetUnitById(int unitId)
		{
			if (unitId == 0)
			{
				return null;
			}
			WuWaGoBaseUnit result;
			this.GameData.AllUnits.TryGetValue(unitId, out result);
			return result;
		}

		// Token: 0x0401D3B9 RID: 119737
		public readonly bool EnableDebug;

		// Token: 0x0401D3BA RID: 119738
		[Nullable(2)]
		private WuWaGoGameData GameDataInner;
	}
}
