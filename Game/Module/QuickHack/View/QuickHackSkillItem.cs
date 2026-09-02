using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack.View
{
	// Token: 0x02005308 RID: 21256
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackSkillItem : UiPanelBase
	{
		// Token: 0x06036440 RID: 222272 RVA: 0x00DAD9FC File Offset: 0x00DABBFC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIExtendToggleSpriteTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06036441 RID: 222273 RVA: 0x00DADBB4 File Offset: 0x00DABDB4
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			extendToggle.bLockStateOnSelect = true;
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnStateChange));
			extendToggle.OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnPointDown));
		}

		// Token: 0x06036442 RID: 222274 RVA: 0x00DADC0D File Offset: 0x00DABE0D
		public void InitSelectSkillAudioPath(string selectSkillAudioPath)
		{
			this.SelectSkillAudioPath = selectSkillAudioPath;
		}

		// Token: 0x06036443 RID: 222275 RVA: 0x00DADC16 File Offset: 0x00DABE16
		public void PlayUseSkillSequence()
		{
			if (this.SequencePlayer == null)
			{
				return;
			}
			this.SequencePlayer.StopPrevSequence(false, true);
			this.SequencePlayer.PlaySequencePurely("PitchOn", false, false);
		}

		// Token: 0x06036444 RID: 222276 RVA: 0x00DADC40 File Offset: 0x00DABE40
		public void PlayDisableSequence()
		{
			if (this.SequencePlayer == null)
			{
				return;
			}
			this.SequencePlayer.StopPrevSequence(false, true);
			this.SequencePlayer.PlaySequencePurely("Refused", false, false);
		}

		// Token: 0x06036445 RID: 222277 RVA: 0x00DADC6C File Offset: 0x00DABE6C
		public void Refresh(QuickHackSkillInstance data, bool isSelected, int gridIndex)
		{
			int num = (gridIndex < QuickHackDefine.quickHackSkillItemOffsets.Count) ? QuickHackDefine.quickHackSkillItemOffsets[gridIndex] : 0;
			base.GetExtendToggle(0).RootUIComp.Get().SetAnchorOffsetX((float)num);
			QuickHackSkillInstance skill = this.Skill;
			if (skill != null)
			{
				skill.UnRegisterOnCheckSkillCanUse(new Action<QuickHackSkillConditionResult>(this.OnCheckSkillCanUse));
			}
			this.RefreshByState(data.GetSkillCanUseInfo().IsSuccess);
			data.RegisterOnCheckSkillCanUse(new Action<QuickHackSkillConditionResult>(this.OnCheckSkillCanUse));
			this.Skill = data;
			QuickHackSkill config = data.GetConfig();
			base.GetText(4).SetText(config.RamCost.ToString(), true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), config.SkillName, Array.Empty<object>());
			base.SetTextureByPath(config.Icon, base.GetTexture(2), null, null);
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			this.RefreshKeyItem(isSelected);
			if (isSelected)
			{
				ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(extendToggle.RootUIComp, true, false, false);
			}
		}

		// Token: 0x06036446 RID: 222278 RVA: 0x00DADD94 File Offset: 0x00DABF94
		protected override void OnBeforeDestroy()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnStateChange));
			extendToggle.OnPointDownCallBack.Unbind();
			this.CancelItemBgAsyncLoad();
			QuickHackSkillInstance skill = this.Skill;
			if (skill != null)
			{
				skill.UnRegisterOnCheckSkillCanUse(new Action<QuickHackSkillConditionResult>(this.OnCheckSkillCanUse));
			}
			this.Skill = null;
		}

		// Token: 0x06036447 RID: 222279 RVA: 0x00DADDF3 File Offset: 0x00DABFF3
		private void OnCheckSkillCanUse(QuickHackSkillConditionResult result)
		{
			this.RefreshByState(result.IsSuccess);
		}

		// Token: 0x06036448 RID: 222280 RVA: 0x00DADE04 File Offset: 0x00DAC004
		private void RefreshByState(bool enable)
		{
			UUIText text = base.GetText(7);
			string textStringId = enable ? "Skill_10001511_HackSkill101" : "Skill_10001511_HackSkill102";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
			if (this.IsEnable == enable)
			{
				return;
			}
			this.IsEnable = enable;
			bool flag = false;
			string resourceId;
			string resourceId2;
			string resourceId3;
			string resourceId4;
			string resourceId5;
			string hexStr;
			if (enable)
			{
				resourceId = "QuickHackSkillEnableBg";
				resourceId2 = "QuickHackSkillEnableHoldBg";
				resourceId3 = "QuickHackSkillEnableIconBg";
				resourceId4 = "QuickHackSkillEnableRamIcon";
				resourceId5 = "QuickHackSkillEnableTagBg";
				hexStr = "#55DAFFFF";
			}
			else
			{
				flag = true;
				resourceId = "QuickHackSkillDisableBg";
				resourceId2 = "QuickHackSkillDisableHoldBg";
				resourceId3 = "QuickHackSkillDisableIconBg";
				resourceId4 = "QuickHackSkillDisableRamIcon";
				resourceId5 = "QuickHackSkillDisableTagBg";
				hexStr = "#FF5753FF";
			}
			this.CancelItemBgAsyncLoad();
			this.ItemBgResourceId = Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId), delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
			{
				this.ItemBgResourceId = -1;
				if (sprite == null || !sprite.IsValid())
				{
					return;
				}
				UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(8);
				if (uiExtendToggleSpriteTransition == null || !uiExtendToggleSpriteTransition.IsValid())
				{
					return;
				}
				uiExtendToggleSpriteTransition.SetStateSprite(EToggleTransitionState.ETT_UnCheckedUnHover, sprite, false);
			}, ResourceSystem.EResourceLoadPriority.Default, this.MemoryTag);
			this.ItemHoldBgResourceId = Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId2), delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
			{
				this.ItemHoldBgResourceId = -1;
				if (sprite == null || !sprite.IsValid())
				{
					return;
				}
				UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = base.GetUiExtendToggleSpriteTransition(8);
				if (uiExtendToggleSpriteTransition == null || !uiExtendToggleSpriteTransition.IsValid())
				{
					return;
				}
				uiExtendToggleSpriteTransition.SetStateSprite(EToggleTransitionState.ETT_UnCheckedHover, sprite, false);
				uiExtendToggleSpriteTransition.SetStateSprite(EToggleTransitionState.ETT_UnCheckedPressed, sprite, false);
				uiExtendToggleSpriteTransition.SetStateSprite(EToggleTransitionState.ETT_CheckedUnHover, sprite, false);
				uiExtendToggleSpriteTransition.SetStateSprite(EToggleTransitionState.ETT_CheckedHover, sprite, false);
				uiExtendToggleSpriteTransition.SetStateSprite(EToggleTransitionState.ETT_CheckedPressed, sprite, false);
			}, ResourceSystem.EResourceLoadPriority.Default, this.MemoryTag);
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId3), base.GetSprite(1), false, null, null);
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId4), base.GetSprite(3), false, null, null);
			this.SetSpriteByPath(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId5), base.GetSprite(6), false, null, null);
			UUIText text2 = base.GetText(4);
			UUIText text3 = base.GetText(5);
			UUITexture texture = base.GetTexture(2);
			UUIItem uuiitem = text2;
			bool bUseChangeColor = flag;
			FColor? fcolor = new FColor?(text2.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			UUIItem uuiitem2 = text3;
			bool bUseChangeColor2 = flag;
			fcolor = new FColor?(text3.changeColor);
			uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
			UUIItem uuiitem3 = text;
			bool bUseChangeColor3 = flag;
			fcolor = new FColor?(text.changeColor);
			uuiitem3.SetChangeColor(bUseChangeColor3, fcolor);
			UUIItem uuiitem4 = texture;
			bool bUseChangeColor4 = flag;
			fcolor = new FColor?(texture.changeColor);
			uuiitem4.SetChangeColor(bUseChangeColor4, fcolor);
			base.GetItem(10).SetColor(FColor.FromHex(hexStr));
			base.GetTexture(9).SetUIActive(!enable);
		}

		// Token: 0x06036449 RID: 222281 RVA: 0x00DAE02C File Offset: 0x00DAC22C
		public void OnSelected()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(extendToggle.RootUIComp, true, false, false);
			this.RefreshKeyItem(true);
		}

		// Token: 0x0603644A RID: 222282 RVA: 0x00DAE06C File Offset: 0x00DAC26C
		public void OnDeselected()
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			this.RefreshKeyItem(false);
		}

		// Token: 0x0603644B RID: 222283 RVA: 0x00DAE086 File Offset: 0x00DAC286
		private void OnStateChange(EToggleState state)
		{
			this.RefreshKeyItem(state == EToggleState.ETT_Checked);
			if (state == EToggleState.ETT_Checked && this.Skill != null)
			{
				ControllerBase<QuickHackController>.Instance.SelectSkill(this.Skill, true);
			}
		}

		// Token: 0x0603644C RID: 222284 RVA: 0x00DAE0B0 File Offset: 0x00DAC2B0
		private void CancelItemBgAsyncLoad()
		{
			if (this.ItemBgResourceId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.ItemBgResourceId);
				this.ItemBgResourceId = -1;
			}
			if (this.ItemHoldBgResourceId != -1)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.ItemHoldBgResourceId);
				this.ItemHoldBgResourceId = -1;
			}
		}

		// Token: 0x0603644D RID: 222285 RVA: 0x00DAE100 File Offset: 0x00DAC300
		private void RefreshKeyItem(bool isSelected)
		{
			UUIItem item = base.GetItem(11);
			List<QuickHackSkillInstance> currentSkillList = ModelBase<QuickHackModel>.Instance.CurrentSkillList;
			bool uiactive = ((currentSkillList != null) ? currentSkillList.Count : 0) > 1 && isSelected;
			item.SetUIActive(uiactive);
		}

		// Token: 0x0603644E RID: 222286 RVA: 0x00DAE137 File Offset: 0x00DAC337
		private void OnPointDown(EToggleState state)
		{
			if (!StringUtils.IsBlank(this.SelectSkillAudioPath))
			{
				Singleton<AudioSystem>.Instance.PostEvent(this.SelectSkillAudioPath);
			}
		}

		// Token: 0x0401F321 RID: 127777
		[Nullable(2)]
		private UiSequencePlayer SequencePlayer;

		// Token: 0x0401F322 RID: 127778
		[Nullable(2)]
		private QuickHackSkillInstance Skill;

		// Token: 0x0401F323 RID: 127779
		private bool IsEnable = true;

		// Token: 0x0401F324 RID: 127780
		private int ItemBgResourceId = -1;

		// Token: 0x0401F325 RID: 127781
		private int ItemHoldBgResourceId = -1;

		// Token: 0x0401F326 RID: 127782
		private string SelectSkillAudioPath = "";

		// Token: 0x0200B23A RID: 45626
		[NullableContext(0)]
		private class EComponentType
		{
			// Token: 0x0403742D RID: 226349
			public const int SkillToggle = 0;

			// Token: 0x0403742E RID: 226350
			public const int IconBgSprite = 1;

			// Token: 0x0403742F RID: 226351
			public const int IconTexture = 2;

			// Token: 0x04037430 RID: 226352
			public const int StateSprite = 3;

			// Token: 0x04037431 RID: 226353
			public const int CostText = 4;

			// Token: 0x04037432 RID: 226354
			public const int NameText = 5;

			// Token: 0x04037433 RID: 226355
			public const int TagBgSprite = 6;

			// Token: 0x04037434 RID: 226356
			public const int TagText = 7;

			// Token: 0x04037435 RID: 226357
			public const int ItemBgSprite = 8;

			// Token: 0x04037436 RID: 226358
			public const int DisableTexture = 9;

			// Token: 0x04037437 RID: 226359
			public const int ClickItem = 10;

			// Token: 0x04037438 RID: 226360
			public const int KeyItem = 11;
		}
	}
}
