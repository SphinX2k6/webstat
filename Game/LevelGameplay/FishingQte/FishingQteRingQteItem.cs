using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006EA7 RID: 28327
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingQteRingQteItem : UiPanelBase
	{
		// Token: 0x06044AF8 RID: 281336 RVA: 0x011DA695 File Offset: 0x011D8895
		public FishingQteRingQteItem(FishingQteGameInfo GameInfo, FishingQteRingInfo RingInfo, [Nullable(2)] IFishingQteConfig RingConfig)
		{
			this.GameInfo = GameInfo;
			this.RingInfo = RingInfo;
			this.RingConfig = RingConfig;
		}

		// Token: 0x06044AF9 RID: 281337 RVA: 0x011DA6D4 File Offset: 0x011D88D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044AFA RID: 281338 RVA: 0x011DA71C File Offset: 0x011D891C
		protected override void OnStart()
		{
			this.TextureRing = base.GetItem(0);
			this.TextureRing.SetUIActive(false);
		}

		// Token: 0x06044AFB RID: 281339 RVA: 0x011DA737 File Offset: 0x011D8937
		protected override void OnBeforeDestroy()
		{
			this.TextureRing = null;
			this.QteAreaTextures.Clear();
			this.PerfectAreaTextures.Clear();
			this.CachedTexture.Clear();
		}

		// Token: 0x06044AFC RID: 281340 RVA: 0x011DA764 File Offset: 0x011D8964
		private int GetAreaRandomSize(List<int> rangeConfig)
		{
			int result = 3;
			if (rangeConfig.Count == 2)
			{
				result = this.RandomRangeInt(rangeConfig[0], rangeConfig[1]);
			}
			return result;
		}

		// Token: 0x06044AFD RID: 281341 RVA: 0x011DA792 File Offset: 0x011D8992
		private int RandomRangeInt(int start, int end)
		{
			return Math.Min(end, (int)Math.Floor(Singleton<MathUtils>.Instance.GetRandomRange((double)start, (double)(end + 1))));
		}

		// Token: 0x06044AFE RID: 281342 RVA: 0x011DA7B0 File Offset: 0x011D89B0
		public void ResetArea(int continuousIndex, EFishingAreaType areaType)
		{
			if (areaType != EFishingAreaType.QteArea)
			{
				if (areaType != EFishingAreaType.PerfectArea)
				{
					return;
				}
				this.RingInfo.RemovePerfectArea(continuousIndex);
				FishingQteRingQteSingleItem fishingQteRingQteSingleItem;
				if (this.PerfectAreaTextures.TryGetValue(continuousIndex, out fishingQteRingQteSingleItem))
				{
					fishingQteRingQteSingleItem.SetUiActive(false);
					this.CachedTexture.Add(fishingQteRingQteSingleItem);
					this.PerfectAreaTextures.Remove(continuousIndex);
				}
			}
			else
			{
				this.RingInfo.RemoveQteArea(continuousIndex);
				FishingQteRingQteSingleItem fishingQteRingQteSingleItem2;
				if (this.QteAreaTextures.TryGetValue(continuousIndex, out fishingQteRingQteSingleItem2))
				{
					fishingQteRingQteSingleItem2.SetUiActive(false);
					this.CachedTexture.Add(fishingQteRingQteSingleItem2);
					this.QteAreaTextures.Remove(continuousIndex);
					return;
				}
			}
		}

		// Token: 0x06044AFF RID: 281343 RVA: 0x011DA83F File Offset: 0x011D8A3F
		public void ResetAreaInLink(int continuousIndex, EFishingAreaType areaType)
		{
			if (areaType != EFishingAreaType.QteArea)
			{
				if (areaType != EFishingAreaType.PerfectArea)
				{
					return;
				}
				this.ResetArea(continuousIndex, EFishingAreaType.PerfectArea);
				this.ResetArea(continuousIndex, EFishingAreaType.QteArea);
			}
			else
			{
				this.ResetArea(continuousIndex, EFishingAreaType.QteArea);
				if (this.PerfectAreaTextures.ContainsKey(continuousIndex))
				{
					this.ResetArea(continuousIndex, EFishingAreaType.PerfectArea);
					return;
				}
			}
		}

		// Token: 0x06044B00 RID: 281344 RVA: 0x011DA87C File Offset: 0x011D8A7C
		public void ResetAllArea()
		{
			foreach (int continuousIndex in this.QteAreaTextures.Keys.ToList<int>())
			{
				this.ResetArea(continuousIndex, EFishingAreaType.QteArea);
			}
			foreach (int continuousIndex2 in this.PerfectAreaTextures.Keys.ToList<int>())
			{
				this.ResetArea(continuousIndex2, EFishingAreaType.PerfectArea);
			}
		}

		// Token: 0x06044B01 RID: 281345 RVA: 0x011DA928 File Offset: 0x011D8B28
		private UniTask GenerateAreaWithTexture(int continuousIndex, EFishingAreaType areaType, int startIndex, int areaSize)
		{
			FishingQteRingQteItem.<GenerateAreaWithTexture>d__16 <GenerateAreaWithTexture>d__;
			<GenerateAreaWithTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GenerateAreaWithTexture>d__.<>4__this = this;
			<GenerateAreaWithTexture>d__.continuousIndex = continuousIndex;
			<GenerateAreaWithTexture>d__.areaType = areaType;
			<GenerateAreaWithTexture>d__.startIndex = startIndex;
			<GenerateAreaWithTexture>d__.areaSize = areaSize;
			<GenerateAreaWithTexture>d__.<>1__state = -1;
			<GenerateAreaWithTexture>d__.<>t__builder.Start<FishingQteRingQteItem.<GenerateAreaWithTexture>d__16>(ref <GenerateAreaWithTexture>d__);
			return <GenerateAreaWithTexture>d__.<>t__builder.Task;
		}

		// Token: 0x06044B02 RID: 281346 RVA: 0x011DA98C File Offset: 0x011D8B8C
		private UniTask GenerateQteArea(int continuousIndex, int startIndex, int areaSize)
		{
			FishingQteRingQteItem.<GenerateQteArea>d__17 <GenerateQteArea>d__;
			<GenerateQteArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GenerateQteArea>d__.<>4__this = this;
			<GenerateQteArea>d__.continuousIndex = continuousIndex;
			<GenerateQteArea>d__.startIndex = startIndex;
			<GenerateQteArea>d__.areaSize = areaSize;
			<GenerateQteArea>d__.<>1__state = -1;
			<GenerateQteArea>d__.<>t__builder.Start<FishingQteRingQteItem.<GenerateQteArea>d__17>(ref <GenerateQteArea>d__);
			return <GenerateQteArea>d__.<>t__builder.Task;
		}

		// Token: 0x06044B03 RID: 281347 RVA: 0x011DA9E8 File Offset: 0x011D8BE8
		public void SpawnAreaAtValidArea(int continuousIndex, RingArea validArea)
		{
			int startCellIndex = validArea.StartCellIndex;
			int endCellIndex = validArea.EndCellIndex;
			int num = FishingQteDefine.calculateCellSize(startCellIndex, endCellIndex);
			int areaRandomSize = this.GetAreaRandomSize(this.RingConfig.RandomArea);
			if (num <= areaRandomSize)
			{
				this.GenerateQteArea(continuousIndex, startCellIndex, num);
				return;
			}
			if (endCellIndex >= startCellIndex)
			{
				int startIndex = this.RandomRangeInt(startCellIndex, endCellIndex - areaRandomSize + 1);
				this.GenerateQteArea(continuousIndex, startIndex, areaRandomSize);
				return;
			}
			int num2 = startCellIndex + num - 1;
			int startIndex2 = this.RandomRangeInt(startCellIndex, num2 - areaRandomSize + 1) % 36;
			this.GenerateQteArea(continuousIndex, startIndex2, areaRandomSize);
		}

		// Token: 0x06044B04 RID: 281348 RVA: 0x011DAA70 File Offset: 0x011D8C70
		private void SpawnWholeRingAllArea()
		{
			ContinuousRingArea continuousRingArea;
			int num = this.RingInfo.GetQteAreas().TryGetValue(0, out continuousRingArea) ? continuousRingArea.StartCellIndex : 0;
			this.ResetAllArea();
			if (this.RingConfig.MultiBoxGroup == 0 || 36 % this.RingConfig.MultiBoxGroup != 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SceneGameplay;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[FishingQte]格子扩展配置有误：不可被等分";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置组数", this.RingConfig.MultiBoxGroup);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			int num2 = 36 / this.RingConfig.MultiBoxGroup;
			int multiBoxGroup = this.RingConfig.MultiBoxGroup;
			int num3 = this.RandomRangeInt(1, 36);
			if (multiBoxGroup == 1 && num != 0)
			{
				int areaRandomSize = this.GetAreaRandomSize(this.RingConfig.RandomArea);
				int startIndex = (num + 18) % 36;
				this.GenerateQteArea(0, startIndex, areaRandomSize);
				return;
			}
			for (int i = 0; i < multiBoxGroup; i++)
			{
				int areaRandomSize2 = this.GetAreaRandomSize(this.RingConfig.RandomArea);
				int startIndex2 = i * num2 + num3 + 1;
				this.GenerateQteArea(i, startIndex2, areaRandomSize2);
			}
		}

		// Token: 0x06044B05 RID: 281349 RVA: 0x011DAB88 File Offset: 0x011D8D88
		private void SpawnIncompleteRingAllArea()
		{
			this.ResetAllArea();
			List<RingArea> validAreas = this.RingInfo.GetValidAreas();
			for (int i = 0; i < validAreas.Count; i++)
			{
				this.SpawnAreaAtValidArea(i, validAreas[i]);
			}
		}

		// Token: 0x06044B06 RID: 281350 RVA: 0x011DABC6 File Offset: 0x011D8DC6
		public void InitAllQteAreas()
		{
			if (this.RingInfo.IsWholeRing)
			{
				this.SpawnWholeRingAllArea();
				return;
			}
			this.SpawnIncompleteRingAllArea();
		}

		// Token: 0x06044B07 RID: 281351 RVA: 0x011DABE4 File Offset: 0x011D8DE4
		public void SpawnContinuousArea(int continuousIndex, EFishingAreaType type = EFishingAreaType.QteArea)
		{
			if (this.RingInfo.IsWholeRing)
			{
				switch (this.RingConfig.RefreshType)
				{
				case 0:
					break;
				case 1:
					this.SpawnWholeRingAllArea();
					return;
				case 2:
					this.ResetAreaInLink(continuousIndex, type);
					if (this.RingInfo.GetQteAreas().Count == 0)
					{
						this.SpawnWholeRingAllArea();
						return;
					}
					break;
				default:
					return;
				}
			}
			else
			{
				List<RingArea> validAreas = this.RingInfo.GetValidAreas();
				this.ResetAreaInLink(continuousIndex, type);
				this.SpawnAreaAtValidArea(continuousIndex, validAreas[continuousIndex]);
			}
		}

		// Token: 0x06044B08 RID: 281352 RVA: 0x011DAC67 File Offset: 0x011D8E67
		public UUIItem GetQteAreaTexture(int continuousIndex)
		{
			return this.QteAreaTextures[continuousIndex].GetRootItem();
		}

		// Token: 0x06044B09 RID: 281353 RVA: 0x011DAC7A File Offset: 0x011D8E7A
		public UUIItem GetPerfectAreaTexture(int continuousIndex)
		{
			return this.PerfectAreaTextures[continuousIndex].GetRootItem();
		}

		// Token: 0x06044B0A RID: 281354 RVA: 0x011DAC90 File Offset: 0x011D8E90
		public void PlayAnim(string sequenceName)
		{
			if (!(sequenceName == "Fail"))
			{
				if (!(sequenceName == "Success"))
				{
					if (!(sequenceName == "PerfectQte"))
					{
						return;
					}
					goto IL_DC;
				}
			}
			else
			{
				foreach (FishingQteRingQteSingleItem fishingQteRingQteSingleItem in this.QteAreaTextures.Values)
				{
					fishingQteRingQteSingleItem.PlayAnim(sequenceName);
				}
				using (Dictionary<int, FishingQteRingQteSingleItem>.ValueCollection.Enumerator enumerator = this.PerfectAreaTextures.Values.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						FishingQteRingQteSingleItem fishingQteRingQteSingleItem2 = enumerator.Current;
						fishingQteRingQteSingleItem2.PlayAnim(sequenceName);
					}
					return;
				}
			}
			using (Dictionary<int, FishingQteRingQteSingleItem>.ValueCollection.Enumerator enumerator = this.QteAreaTextures.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FishingQteRingQteSingleItem fishingQteRingQteSingleItem3 = enumerator.Current;
					fishingQteRingQteSingleItem3.PlayAnim(sequenceName);
				}
				return;
			}
			IL_DC:
			foreach (FishingQteRingQteSingleItem fishingQteRingQteSingleItem4 in this.PerfectAreaTextures.Values)
			{
				fishingQteRingQteSingleItem4.PlayAnim(sequenceName);
			}
		}

		// Token: 0x040263CE RID: 156622
		protected FishingQteGameInfo GameInfo;

		// Token: 0x040263CF RID: 156623
		protected FishingQteRingInfo RingInfo;

		// Token: 0x040263D0 RID: 156624
		[Nullable(2)]
		protected IFishingQteConfig RingConfig;

		// Token: 0x040263D1 RID: 156625
		[Nullable(2)]
		private UUIItem TextureRing;

		// Token: 0x040263D2 RID: 156626
		private Dictionary<int, FishingQteRingQteSingleItem> QteAreaTextures = new Dictionary<int, FishingQteRingQteSingleItem>();

		// Token: 0x040263D3 RID: 156627
		private Dictionary<int, FishingQteRingQteSingleItem> PerfectAreaTextures = new Dictionary<int, FishingQteRingQteSingleItem>();

		// Token: 0x040263D4 RID: 156628
		private List<FishingQteRingQteSingleItem> CachedTexture = new List<FishingQteRingQteSingleItem>();

		// Token: 0x0200CB79 RID: 52089
		[NullableContext(0)]
		private class EQteComponents
		{
			// Token: 0x0403E6FE RID: 255742
			public const int QteItem = 0;
		}
	}
}
