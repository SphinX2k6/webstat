using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.BossRush
{
	// Token: 0x020069B8 RID: 27064
	public class BossRushBuffSelectInGameItem : UiPanelBase
	{
		// Token: 0x060431AF RID: 274863 RVA: 0x0113C3B0 File Offset: 0x0113A5B0
		public void SetClickCallBack([Nullable(new byte[]
		{
			1,
			2
		})] Action<BossRushBuffSelectInGameItem> callback)
		{
			this.ClickCallBack = callback;
		}

		// Token: 0x060431B0 RID: 274864 RVA: 0x0113C3BC File Offset: 0x0113A5BC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(this.SelfToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060431B1 RID: 274865 RVA: 0x0113C590 File Offset: 0x0113A790
		protected override void OnStart()
		{
			base.GetHorizontalLayout(3).RootUIComp.Get().SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetSprite(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			base.GetItem(9).SetUIActive(false);
			base.GetItem(10).SetUIActive(false);
		}

		// Token: 0x060431B2 RID: 274866 RVA: 0x0113C5FC File Offset: 0x0113A7FC
		public void RefreshItem(int buffId)
		{
			BossRushConfig instance = ConfigBase<BossRushConfig>.Instance;
			BossRushBuff? bossRushBuff = (instance != null) ? instance.GetBossRushBuffConfigById(buffId) : null;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), bossRushBuff.Value.Name, Array.Empty<object>());
			List<string> list = new List<string>();
			foreach (string input in bossRushBuff.Value.DescriptionParamIter())
			{
				Match match = BossRushBuffSelectInGameItem.regex.Match(input);
				if (match.Success && match.Groups.Count > 1)
				{
					list.AddRange(match.Groups[1].Value.Split(',', StringSplitOptions.None));
				}
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), bossRushBuff.Value.Description, list.ToArray());
			base.SetTextureByPath(bossRushBuff.Value.Texture, base.GetTexture(1), null, null);
		}

		// Token: 0x060431B3 RID: 274867 RVA: 0x0113C72C File Offset: 0x0113A92C
		private void SelfToggle(EToggleState state)
		{
			Action<BossRushBuffSelectInGameItem> clickCallBack = this.ClickCallBack;
			if (clickCallBack == null)
			{
				return;
			}
			clickCallBack((state == EToggleState.ETT_Checked) ? this : null);
		}

		// Token: 0x060431B4 RID: 274868 RVA: 0x0113C746 File Offset: 0x0113A946
		public void SetToggleUnCheck()
		{
			base.GetExtendToggle(5).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x04025652 RID: 153170
		[Nullable(new byte[]
		{
			1,
			2
		})]
		public Action<BossRushBuffSelectInGameItem> ClickCallBack;

		// Token: 0x04025653 RID: 153171
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static Regex regex = new Regex("\\[(.*?)\\]");

		// Token: 0x0200C940 RID: 51520
		private class EComponent
		{
			// Token: 0x0403DE57 RID: 253527
			public const int QualityBgTexture = 0;

			// Token: 0x0403DE58 RID: 253528
			public const int IconTexture = 1;

			// Token: 0x0403DE59 RID: 253529
			public const int NameText = 2;

			// Token: 0x0403DE5A RID: 253530
			public const int ElementLayout = 3;

			// Token: 0x0403DE5B RID: 253531
			public const int DescText = 4;

			// Token: 0x0403DE5C RID: 253532
			public const int SelfToggle = 5;

			// Token: 0x0403DE5D RID: 253533
			public const int NewItem = 6;

			// Token: 0x0403DE5E RID: 253534
			public const int QualityLineSprite = 7;

			// Token: 0x0403DE5F RID: 253535
			public const int GoldItem = 8;

			// Token: 0x0403DE60 RID: 253536
			public const int YellowItem = 9;

			// Token: 0x0403DE61 RID: 253537
			public const int ButtonItem = 10;
		}
	}
}
