using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006322 RID: 25378
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SpringManorAlbumTaskItem : GridProxyAbstract<AlbumTaskData>
	{
		// Token: 0x0603FC50 RID: 261200 RVA: 0x010598DC File Offset: 0x01057ADC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick))
			};
		}

		// Token: 0x0603FC51 RID: 261201 RVA: 0x0105999B File Offset: 0x01057B9B
		private void OnClick(EToggleState state)
		{
			if (this.OnToggleCallBack != null && this.Data != null)
			{
				this.OnToggleCallBack(this.Data, this.Index);
			}
		}

		// Token: 0x0603FC52 RID: 261202 RVA: 0x010599C4 File Offset: 0x01057BC4
		public void SetToggleCallBack(Action<AlbumTaskData, int> callBack)
		{
			this.OnToggleCallBack = callBack;
		}

		// Token: 0x0603FC53 RID: 261203 RVA: 0x010599CD File Offset: 0x01057BCD
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelectedState(true);
		}

		// Token: 0x0603FC54 RID: 261204 RVA: 0x010599D6 File Offset: 0x01057BD6
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelectedState(false);
		}

		// Token: 0x0603FC55 RID: 261205 RVA: 0x010599E0 File Offset: 0x01057BE0
		public override void Refresh(AlbumTaskData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.Index = gridIndex;
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			BookItem? bookItem = (instance != null) ? instance.GetSpringManorBookItemById(data.ConfigId) : null;
			if (bookItem == null)
			{
				return;
			}
			this.CurTaskType = data.Type;
			this.SetSelectedState(isSelected);
			bool flag = data.State == EBrochureState.Unlock;
			bool flag2 = data.State == EBrochureState.Rewarded;
			if (flag || flag2)
			{
				UUIText text = base.GetText(1);
				if (text != null)
				{
					text.ShowTextNew(bookItem.Value.DescriptionTitle);
				}
			}
			else
			{
				UUIText text2 = base.GetText(1);
				if (text2 != null)
				{
					text2.ShowTextNew((!string.IsNullOrEmpty(bookItem.Value.GuideTitle)) ? bookItem.Value.GuideTitle : bookItem.Value.DescriptionTitle);
				}
			}
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(data.IsFollowing);
			}
			if (data.IsFollowing)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(data.IsMainQuest ? "SP_IconTaskZhuXian" : "SP_IconTaskYaoYue");
				this.SetSpriteByPath(resourcePath, base.GetSprite(4), false, null, null);
			}
			UUISprite sprite2 = base.GetSprite(5);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(flag || flag2);
			}
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(flag);
		}

		// Token: 0x0603FC56 RID: 261206 RVA: 0x01059B42 File Offset: 0x01057D42
		public void SetSelectedState(bool isSelected)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			this.SetSelectedIcon(isSelected);
		}

		// Token: 0x0603FC57 RID: 261207 RVA: 0x01059B68 File Offset: 0x01057D68
		private void SetSelectedIcon(bool isSelected)
		{
			string text = null;
			if (this.CurTaskType == EBrochureType.Character)
			{
				UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
				text = ((instance != null) ? instance.GetResourcePath(isSelected ? "SP_AlbumTabBIconASel" : "SP_AlbumTabBIconANml") : null);
			}
			else if (this.CurTaskType == EBrochureType.EasterEggBook)
			{
				UiResourceConfig instance2 = ConfigBase<UiResourceConfig>.Instance;
				text = ((instance2 != null) ? instance2.GetResourcePath(isSelected ? "SP_AlbumTabBIconBNml" : "SP_AlbumTabBIconBSel") : null);
			}
			if (!string.IsNullOrEmpty(text))
			{
				this.SetSpriteByPath(text, base.GetSprite(2), false, null, delegate(bool _)
				{
					(base.GetSprite(2).GetOwner().GetComponentByClass(UUIExtendToggleSpriteTransition.StaticClass()) as UUIExtendToggleSpriteTransition).SetAllStateSprite(base.GetSprite(2).GetSprite());
				});
			}
		}

		// Token: 0x04023CCD RID: 146637
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<AlbumTaskData, int> OnToggleCallBack;

		// Token: 0x04023CCE RID: 146638
		[Nullable(2)]
		private AlbumTaskData Data;

		// Token: 0x04023CCF RID: 146639
		private EBrochureType CurTaskType = EBrochureType.Brochure;

		// Token: 0x04023CD0 RID: 146640
		private int Index;
	}
}
