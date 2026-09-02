using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E34 RID: 20020
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseLevelTargetPanel : UiPanelBase
	{
		// Token: 0x06033C03 RID: 211971 RVA: 0x00CEFD24 File Offset: 0x00CEDF24
		public UniTask Init(UUIItem item)
		{
			TrapDefenseLevelTargetPanel.<Init>d__6 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.item = item;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<TrapDefenseLevelTargetPanel.<Init>d__6>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06033C04 RID: 211972 RVA: 0x00CEFD6F File Offset: 0x00CEDF6F
		protected override void OnBeforeCreate()
		{
		}

		// Token: 0x06033C05 RID: 211973 RVA: 0x00CEFD74 File Offset: 0x00CEDF74
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C06 RID: 211974 RVA: 0x00CEFE64 File Offset: 0x00CEE064
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseLevelTargetPanel.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseLevelTargetPanel.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033C07 RID: 211975 RVA: 0x00CEFEA7 File Offset: 0x00CEE0A7
		protected override void OnStart()
		{
		}

		// Token: 0x06033C08 RID: 211976 RVA: 0x00CEFEA9 File Offset: 0x00CEE0A9
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x06033C09 RID: 211977 RVA: 0x00CEFEAB File Offset: 0x00CEE0AB
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033C0A RID: 211978 RVA: 0x00CEFEAD File Offset: 0x00CEE0AD
		public void UpdateData(TrapDefenseLevelData data)
		{
			this.LevelData = data;
			this.LayoutTarget.RefreshByData(data.GetTargetInfoList(), null, false);
			this.PanelRewardInfo.UpdateData(data);
			this.PanelWaveInfo.UpdateData(data);
			this.PanelGoToInfo.UpdateData(data);
		}

		// Token: 0x06033C0B RID: 211979 RVA: 0x00CEFEED File Offset: 0x00CEE0ED
		public TrapDefenseLevelTargetItem CreateItemTarget()
		{
			return new TrapDefenseLevelTargetItem();
		}

		// Token: 0x0401DF44 RID: 122692
		public TrapDefenseLevelData LevelData;

		// Token: 0x0401DF45 RID: 122693
		public GenericLayout<TrapDefenseLevelTargetItem, ITrapDefenseLevelTargetItemData> LayoutTarget;

		// Token: 0x0401DF46 RID: 122694
		public TrapDefenseLevelRewardPanel PanelRewardInfo;

		// Token: 0x0401DF47 RID: 122695
		public TrapDefenseLevelWavePanel PanelWaveInfo;

		// Token: 0x0401DF48 RID: 122696
		public TrapDefenseLevelGoToPanel PanelGoToInfo;

		// Token: 0x0200ADBB RID: 44475
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F2B RID: 220971
			public const int LayoutTarget = 0;

			// Token: 0x04035F2C RID: 220972
			public const int ItemTarget = 1;

			// Token: 0x04035F2D RID: 220973
			public const int ItemRewardRoot = 2;

			// Token: 0x04035F2E RID: 220974
			public const int ItemRewardInfo = 3;

			// Token: 0x04035F2F RID: 220975
			public const int ItemWaveInfo = 4;

			// Token: 0x04035F30 RID: 220976
			public const int ItemGoTo = 5;
		}
	}
}
