using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BC3 RID: 23491
	public class InstanceDungeonGuideView : UiViewBase
	{
		// Token: 0x0603B77E RID: 243582 RVA: 0x00F13315 File Offset: 0x00F11515
		[NullableContext(1)]
		public InstanceDungeonGuideView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603B77F RID: 243583 RVA: 0x00F13320 File Offset: 0x00F11520
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickedCloseButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B780 RID: 243584 RVA: 0x00F134AE File Offset: 0x00F116AE
		private void OnClickedCloseButton()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603B781 RID: 243585 RVA: 0x00F134B8 File Offset: 0x00F116B8
		protected override void OnStart()
		{
			base.GetButton(4).RootUIComp.Get().SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			base.GetItem(2).SetUIActive(false);
			this.RefreshGuideView();
		}

		// Token: 0x0603B782 RID: 243586 RVA: 0x00F1351C File Offset: 0x00F1171C
		private void RefreshGuideView()
		{
			int currentInstanceDungeonGuideValue = ModelBase<InstanceDungeonGuideModel>.Instance.GetCurrentInstanceDungeonGuideValue();
			if (currentInstanceDungeonGuideValue == 0)
			{
				return;
			}
			IReadOnlyList<HelpText> helpContentInfoByGroupId = ConfigBase<HelpConfig>.Instance.GetHelpContentInfoByGroupId(currentInstanceDungeonGuideValue);
			if (helpContentInfoByGroupId == null || helpContentInfoByGroupId.Count < 1)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), helpContentInfoByGroupId[0].Title, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), helpContentInfoByGroupId[0].Content, Array.Empty<object>());
			string picture = helpContentInfoByGroupId[0].Picture;
			if (string.IsNullOrEmpty(picture))
			{
				base.GetTexture(1).SetUIActive(false);
				return;
			}
			base.GetTexture(1).SetUIActive(true);
			base.SetTextureByPath(picture, base.GetTexture(1), null, null);
		}

		// Token: 0x0200BC2D RID: 48173
		private static class EChildType
		{
			// Token: 0x0403A0AD RID: 237741
			public const int TextTitle = 0;

			// Token: 0x0403A0AE RID: 237742
			public const int DescriptionTexture = 1;

			// Token: 0x0403A0AF RID: 237743
			public const int EffectItem = 2;

			// Token: 0x0403A0B0 RID: 237744
			public const int TextDescription = 3;

			// Token: 0x0403A0B1 RID: 237745
			public const int DetailButton = 4;

			// Token: 0x0403A0B2 RID: 237746
			public const int ItemElement = 5;

			// Token: 0x0403A0B3 RID: 237747
			public const int CloseButton = 6;

			// Token: 0x0403A0B4 RID: 237748
			public const int TrialPanel = 7;

			// Token: 0x0403A0B5 RID: 237749
			public const int BigTitle = 8;
		}
	}
}
