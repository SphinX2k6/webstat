using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A0 RID: 26272
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffOverview : UiPanelBase
	{
		// Token: 0x060419B6 RID: 268726 RVA: 0x010D273C File Offset: 0x010D093C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060419B7 RID: 268727 RVA: 0x010D282C File Offset: 0x010D0A2C
		protected override UniTask OnBeforeStartAsync()
		{
			MowingBuffOverview.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MowingBuffOverview.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419B8 RID: 268728 RVA: 0x010D2870 File Offset: 0x010D0A70
		private UniTask CreateBuffIntroduceAsync()
		{
			MowingBuffOverview.<CreateBuffIntroduceAsync>d__7 <CreateBuffIntroduceAsync>d__;
			<CreateBuffIntroduceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateBuffIntroduceAsync>d__.<>4__this = this;
			<CreateBuffIntroduceAsync>d__.<>1__state = -1;
			<CreateBuffIntroduceAsync>d__.<>t__builder.Start<MowingBuffOverview.<CreateBuffIntroduceAsync>d__7>(ref <CreateBuffIntroduceAsync>d__);
			return <CreateBuffIntroduceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419B9 RID: 268729 RVA: 0x010D28B3 File Offset: 0x010D0AB3
		private void CreateFilterEntrance()
		{
			base.GetItem(2).SetUIActive(false);
		}

		// Token: 0x060419BA RID: 268730 RVA: 0x010D28C2 File Offset: 0x010D0AC2
		private void CreateBuffContent()
		{
			this.BuffContent = new GenericLayout<MowingBuffGridGroup, IMowingBuffGridGroupData>(base.GetVerticalLayout(3), new Func<MowingBuffGridGroup>(this.BuildGridGroup), null, true, true);
		}

		// Token: 0x060419BB RID: 268731 RVA: 0x010D28E8 File Offset: 0x010D0AE8
		public UniTask RefreshByCustomDataAsync(IMowingBuffOverviewData data)
		{
			MowingBuffOverview.<RefreshByCustomDataAsync>d__10 <RefreshByCustomDataAsync>d__;
			<RefreshByCustomDataAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshByCustomDataAsync>d__.<>4__this = this;
			<RefreshByCustomDataAsync>d__.data = data;
			<RefreshByCustomDataAsync>d__.<>1__state = -1;
			<RefreshByCustomDataAsync>d__.<>t__builder.Start<MowingBuffOverview.<RefreshByCustomDataAsync>d__10>(ref <RefreshByCustomDataAsync>d__);
			return <RefreshByCustomDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419BC RID: 268732 RVA: 0x010D2934 File Offset: 0x010D0B34
		public UniTask PlayStartSequenceAsync()
		{
			MowingBuffOverview.<PlayStartSequenceAsync>d__11 <PlayStartSequenceAsync>d__;
			<PlayStartSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayStartSequenceAsync>d__.<>4__this = this;
			<PlayStartSequenceAsync>d__.<>1__state = -1;
			<PlayStartSequenceAsync>d__.<>t__builder.Start<MowingBuffOverview.<PlayStartSequenceAsync>d__11>(ref <PlayStartSequenceAsync>d__);
			return <PlayStartSequenceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060419BD RID: 268733 RVA: 0x010D2978 File Offset: 0x010D0B78
		public void PlayUnlockSequenceAsync()
		{
			if (this.Data == null)
			{
				return;
			}
			foreach (MowingBuffGridGroup mowingBuffGridGroup in this.BuffContent.GetLayoutItemList())
			{
				foreach (MowingBuffGridItem mowingBuffGridItem in mowingBuffGridGroup.GetBuffGridItemLayout().GetLayoutItemList())
				{
					if (mowingBuffGridItem.CheckNeedPlayUnlockSequence())
					{
						mowingBuffGridItem.PlayUnlockEffect();
					}
				}
			}
		}

		// Token: 0x060419BE RID: 268734 RVA: 0x010D2A20 File Offset: 0x010D0C20
		private MowingBuffGridGroup BuildGridGroup()
		{
			return new MowingBuffGridGroup();
		}

		// Token: 0x04024A29 RID: 150057
		[Nullable(2)]
		private IMowingBuffOverviewData Data;

		// Token: 0x04024A2A RID: 150058
		private MowingBuffIntroduce BuffIntroduce;

		// Token: 0x04024A2B RID: 150059
		private GenericLayout<MowingBuffGridGroup, IMowingBuffGridGroupData> BuffContent;

		// Token: 0x04024A2C RID: 150060
		private UiSequencePlayer Player;

		// Token: 0x0200C6AD RID: 50861
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D2D2 RID: 250578
			public const int IntroduceItem = 0;

			// Token: 0x0403D2D3 RID: 250579
			public const int NonExistRoot = 1;

			// Token: 0x0403D2D4 RID: 250580
			public const int FilterItem = 2;

			// Token: 0x0403D2D5 RID: 250581
			public const int BuffLayout = 3;

			// Token: 0x0403D2D6 RID: 250582
			public const int BuffItem = 4;

			// Token: 0x0403D2D7 RID: 250583
			public const int ExistRoot = 5;
		}
	}
}
