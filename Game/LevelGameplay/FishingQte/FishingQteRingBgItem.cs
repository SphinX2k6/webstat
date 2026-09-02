using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006EA5 RID: 28325
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingQteRingBgItem : UiPanelBase
	{
		// Token: 0x06044AEC RID: 281324 RVA: 0x011DA312 File Offset: 0x011D8512
		public FishingQteRingBgItem(FishingQteRingInfo RingInfo, IFishingQteConfig RingConfig)
		{
			this.RingInfo = RingInfo;
			this.RingConfig = RingConfig;
		}

		// Token: 0x06044AED RID: 281325 RVA: 0x011DA334 File Offset: 0x011D8534
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

		// Token: 0x06044AEE RID: 281326 RVA: 0x011DA37C File Offset: 0x011D857C
		protected override void OnStart()
		{
		}

		// Token: 0x06044AEF RID: 281327 RVA: 0x011DA37E File Offset: 0x011D857E
		protected override void OnBeforeDestroy()
		{
			this.BgItemList.Clear();
		}

		// Token: 0x06044AF0 RID: 281328 RVA: 0x011DA38C File Offset: 0x011D858C
		public UniTask SpawnBgArea()
		{
			FishingQteRingBgItem.<SpawnBgArea>d__7 <SpawnBgArea>d__;
			<SpawnBgArea>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SpawnBgArea>d__.<>4__this = this;
			<SpawnBgArea>d__.<>1__state = -1;
			<SpawnBgArea>d__.<>t__builder.Start<FishingQteRingBgItem.<SpawnBgArea>d__7>(ref <SpawnBgArea>d__);
			return <SpawnBgArea>d__.<>t__builder.Task;
		}

		// Token: 0x06044AF1 RID: 281329 RVA: 0x011DA3D0 File Offset: 0x011D85D0
		public void PlayAnim(string sequenceName)
		{
			foreach (FishingQteRingBgSingleItem fishingQteRingBgSingleItem in this.BgItemList)
			{
				fishingQteRingBgSingleItem.PlayAnim(sequenceName);
			}
		}

		// Token: 0x040263C7 RID: 156615
		protected FishingQteRingInfo RingInfo;

		// Token: 0x040263C8 RID: 156616
		protected IFishingQteConfig RingConfig;

		// Token: 0x040263C9 RID: 156617
		protected List<FishingQteRingBgSingleItem> BgItemList = new List<FishingQteRingBgSingleItem>();

		// Token: 0x0200CB75 RID: 52085
		[NullableContext(0)]
		private class EBgComponents
		{
			// Token: 0x0403E6F2 RID: 255730
			public const int BgRing = 0;
		}
	}
}
