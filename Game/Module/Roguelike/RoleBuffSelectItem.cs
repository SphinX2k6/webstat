using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051B4 RID: 20916
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoleBuffSelectItem : GridProxyAbstract<RogueGainEntry>
	{
		// Token: 0x06035C5C RID: 220252 RVA: 0x00D86179 File Offset: 0x00D84379
		public override void Refresh(RogueGainEntry data, bool isSelected, int gridIndex)
		{
			this.Update(data);
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06035C5D RID: 220253 RVA: 0x00D86199 File Offset: 0x00D84399
		public void Update(RogueGainEntry rogueGainEntry)
		{
			this.RogueGainEntry = rogueGainEntry;
			this.RefreshPanel();
		}

		// Token: 0x06035C5E RID: 220254 RVA: 0x00D861A8 File Offset: 0x00D843A8
		public void SetToggleStateChangeCallback(Action<int, bool> callback)
		{
			this.ToggleStateChangeCallback = callback;
		}

		// Token: 0x06035C5F RID: 220255 RVA: 0x00D861B1 File Offset: 0x00D843B1
		public bool IsSelect()
		{
			return base.GetExtendToggle(0).GetToggleState() == EToggleState.ETT_Checked;
		}

		// Token: 0x06035C60 RID: 220256 RVA: 0x00D861C4 File Offset: 0x00D843C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.SelfToggle));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickBtnDetail));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035C61 RID: 220257 RVA: 0x00D86332 File Offset: 0x00D84532
		private void SelfToggle(EToggleState state)
		{
			Action<int, bool> toggleStateChangeCallback = this.ToggleStateChangeCallback;
			if (toggleStateChangeCallback == null)
			{
				return;
			}
			toggleStateChangeCallback(base.GridIndex, state == EToggleState.ETT_Checked);
		}

		// Token: 0x06035C62 RID: 220258 RVA: 0x00D8634E File Offset: 0x00D8454E
		private void OnClickBtnDetail()
		{
			Action<int> onClickBtnDetailCallback = this.OnClickBtnDetailCallback;
			if (onClickBtnDetailCallback == null)
			{
				return;
			}
			onClickBtnDetailCallback(base.GridIndex);
		}

		// Token: 0x06035C63 RID: 220259 RVA: 0x00D86368 File Offset: 0x00D84568
		public void RefreshPanel()
		{
			RogueCharacterBuff? rogueCharacterBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterBuffConfig(this.RogueGainEntry.ConfigId);
			if (rogueCharacterBuffConfig == null)
			{
				return;
			}
			if (ModelBase<RoguelikeModel>.Instance.GetDescModel() == EDescModel.SIMPLE)
			{
				base.GetText(1).ShowTextNew(rogueCharacterBuffConfig.Value.AffixDescSimple);
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueCharacterBuffConfig.Value.AffixDesc, rogueCharacterBuffConfig.Value.AffixDescParam());
			}
			base.GetText(3).ShowTextNew(rogueCharacterBuffConfig.Value.AffixTitle);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("RogueCharacterBuff_Type", null);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string id in rogueCharacterBuffConfig.Value.AffixTypeListIter())
			{
				string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew(id, null);
				stringBuilder.Append(StringUtils.Format(localTextNew, new string[]
				{
					localTextNew2
				}));
			}
			if (rogueCharacterBuffConfig.Value.AffixTypeListLength > 0)
			{
				base.GetText(6).ShowTextNew(stringBuilder.ToString());
				base.GetText(6).SetUIActive(true);
			}
			else
			{
				base.GetText(6).SetUIActive(false);
			}
			this.SetSpriteByPath(rogueCharacterBuffConfig.Value.AffixIcon, base.GetSprite(2), false, null, null);
			base.GetItem(4).SetUIActive(this.RogueGainEntry.IsNew);
		}

		// Token: 0x06035C64 RID: 220260 RVA: 0x00D86500 File Offset: 0x00D84700
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06035C65 RID: 220261 RVA: 0x00D86513 File Offset: 0x00D84713
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x0401EDAB RID: 126379
		[Nullable(2)]
		public RogueGainEntry RogueGainEntry;

		// Token: 0x0401EDAC RID: 126380
		[Nullable(2)]
		private Action<int, bool> ToggleStateChangeCallback;

		// Token: 0x0401EDAD RID: 126381
		[Nullable(2)]
		public Action<int> OnClickBtnDetailCallback;

		// Token: 0x0200B191 RID: 45457
		[NullableContext(0)]
		public static class ERoleBuffSelectItemCom
		{
			// Token: 0x04037113 RID: 225555
			public const int SelfToggle = 0;

			// Token: 0x04037114 RID: 225556
			public const int DescText = 1;

			// Token: 0x04037115 RID: 225557
			public const int SpriteIcon = 2;

			// Token: 0x04037116 RID: 225558
			public const int TxtName = 3;

			// Token: 0x04037117 RID: 225559
			public const int NewItem = 4;

			// Token: 0x04037118 RID: 225560
			public const int BtnDetail = 5;

			// Token: 0x04037119 RID: 225561
			public const int TxtClassify = 6;
		}
	}
}
