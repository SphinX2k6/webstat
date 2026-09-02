using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi
{
	// Token: 0x02005055 RID: 20565
	[NullableContext(2)]
	[Nullable(0)]
	public class RoleLevelUpSuccessAttributeView : UiViewBase
	{
		// Token: 0x06034F23 RID: 216867 RVA: 0x00D46DC3 File Offset: 0x00D44FC3
		[NullableContext(1)]
		public RoleLevelUpSuccessAttributeView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06034F24 RID: 216868 RVA: 0x00D46DCC File Offset: 0x00D44FCC
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIDynScrollViewComponent)),
				new ValueTuple<int, Type>(7, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(2, new Action(this.OnClickButton)),
				new ValueTuple<int, Delegate>(7, new Action(this.OnClickButton))
			};
		}

		// Token: 0x06034F25 RID: 216869 RVA: 0x00D46F2C File Offset: 0x00D4512C
		protected override void OnBeforeCreate()
		{
			if (this.OpenParam == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Role, ELogAuthor.YYZ, "RoleLevelUpSuccessAttributeView 打开失败,未传入界面数据", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.Data = (ILevelUpSuccessAttributeData)this.OpenParam;
			this.SetAudio();
		}

		// Token: 0x06034F26 RID: 216870 RVA: 0x00D46F78 File Offset: 0x00D45178
		protected override UniTask OnBeforeStartAsync()
		{
			RoleLevelUpSuccessAttributeView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleLevelUpSuccessAttributeView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034F27 RID: 216871 RVA: 0x00D46FBC File Offset: 0x00D451BC
		protected override void OnStart()
		{
			UUIItem item = base.GetItem(5);
			this.LevelPanel = new LevelShowItem();
			this.LevelPanel.CreateThenShowByActor(item.GetOwner(), null);
			bool valueOrDefault = this.Data.WiderScrollView.GetValueOrDefault();
			base.GetItem(9).SetUIActive(valueOrDefault);
			base.GetItem(3).SetUIActive(!valueOrDefault);
			UUIItem uuiitem = valueOrDefault ? base.GetItem(9) : base.GetItem(3);
			UUIDynScrollViewComponent uidynScrollViewComponent = base.GetUIDynScrollViewComponent(6);
			uidynScrollViewComponent.RootUIComp.Get().SetWidth(uuiitem.GetWidth());
			base.GetItem(8).SetWidth(uuiitem.GetWidth());
			this.AttributeSlotDynItem = new AttributeSlotDynItem();
			this.AttributeDynScrollView = new DynamicScrollView<AttributeDynScrollItem, AttributeSlotDynItem, IAttributeInfo>(uidynScrollViewComponent, uuiitem, this.AttributeSlotDynItem, (IAttributeInfo _1, UUIItem _2, int _3) => new AttributeDynScrollItem());
			this.AttributeDynScrollView.Init().Forget();
		}

		// Token: 0x06034F28 RID: 216872 RVA: 0x00D470B7 File Offset: 0x00D452B7
		protected override void OnBeforeShow()
		{
			this.Refresh();
		}

		// Token: 0x06034F29 RID: 216873 RVA: 0x00D470BF File Offset: 0x00D452BF
		protected override void OnBeforeDestroy()
		{
			this.LevelPanel.Destroy(null);
			this.LevelPanel = null;
			this.AttributeDynScrollView.ClearChildren();
			this.AttributeDynScrollView = null;
		}

		// Token: 0x06034F2A RID: 216874 RVA: 0x00D470E8 File Offset: 0x00D452E8
		private void SetAudio()
		{
			string audioId = this.Data.AudioId;
			if (audioId != null)
			{
				string path = ConfigBase<AudioConfig>.Instance.GetAudioPath(audioId).Value.Path;
				base.SetAudioEvent(path);
			}
		}

		// Token: 0x06034F2B RID: 216875 RVA: 0x00D47128 File Offset: 0x00D45328
		private void OnClickButton()
		{
			Action clickFunction = this.Data.ClickFunction;
			if (clickFunction != null)
			{
				clickFunction();
			}
			base.CloseMe(null);
		}

		// Token: 0x06034F2C RID: 216876 RVA: 0x00D47151 File Offset: 0x00D45351
		public void Refresh()
		{
			this.SetTitle();
			this.SetTipsText();
			this.RefreshLevelPanel();
			this.RefreshStrengthInfo();
			this.RefreshAttributePanel();
			this.RefreshArrowPanel();
		}

		// Token: 0x06034F2D RID: 216877 RVA: 0x00D47178 File Offset: 0x00D45378
		private void SetTipsText()
		{
			string key = this.Data.ClickText ?? "Text_BackToView_Text";
			base.GetText(1).ShowTextNew(key);
		}

		// Token: 0x06034F2E RID: 216878 RVA: 0x00D471A8 File Offset: 0x00D453A8
		private void SetTitle()
		{
			string key = this.Data.Title ?? "Text_LevelUpSuccessful_Text";
			base.GetText(0).ShowTextNew(key);
		}

		// Token: 0x06034F2F RID: 216879 RVA: 0x00D471D8 File Offset: 0x00D453D8
		private void RefreshLevelPanel()
		{
			ILevelInfo levelInfo = this.Data.LevelInfo;
			if (levelInfo != null)
			{
				this.LevelPanel.Refresh(levelInfo.PreUpgradeLv, levelInfo.UpgradeLv, levelInfo.FormatStringId, levelInfo.IsMaxLevel);
			}
			base.GetItem(5).SetUIActive(levelInfo != null);
		}

		// Token: 0x06034F30 RID: 216880 RVA: 0x00D47228 File Offset: 0x00D45428
		private void RefreshStrengthInfo()
		{
			IStrengthUpgradeData strengthUpgradeData = this.Data.StrengthUpgradeData;
			if (strengthUpgradeData != null)
			{
				this.StrengthItem.Update(strengthUpgradeData);
			}
		}

		// Token: 0x06034F31 RID: 216881 RVA: 0x00D47250 File Offset: 0x00D45450
		private void RefreshAttributePanel()
		{
			if (this.Data.AttributeInfo == null || this.Data.AttributeInfo.Count == 0)
			{
				base.GetUIDynScrollViewComponent(6).RootUIComp.Get().SetUIActive(false);
				return;
			}
			this.AttributeDynScrollView.RefreshByData(this.Data.AttributeInfo.ToArray(), false, false);
		}

		// Token: 0x06034F32 RID: 216882 RVA: 0x00D472B4 File Offset: 0x00D454B4
		private void RefreshArrowPanel()
		{
			base.GetItem(4).SetUIActive(this.Data.IsShowArrow.GetValueOrDefault());
		}

		// Token: 0x0401E840 RID: 124992
		private ILevelUpSuccessAttributeData Data;

		// Token: 0x0401E841 RID: 124993
		private LevelShowItem LevelPanel;

		// Token: 0x0401E842 RID: 124994
		private StrengthUpgradeBarItem StrengthItem;

		// Token: 0x0401E843 RID: 124995
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private DynamicScrollView<AttributeDynScrollItem, AttributeSlotDynItem, IAttributeInfo> AttributeDynScrollView;

		// Token: 0x0401E844 RID: 124996
		private AttributeSlotDynItem AttributeSlotDynItem;

		// Token: 0x0200AFF5 RID: 45045
		[NullableContext(0)]
		private enum ERoleSuccessAttributeNode
		{
			// Token: 0x04036958 RID: 223576
			Title,
			// Token: 0x04036959 RID: 223577
			TipsText,
			// Token: 0x0403695A RID: 223578
			TipsButton,
			// Token: 0x0403695B RID: 223579
			AttributeSlot,
			// Token: 0x0403695C RID: 223580
			PanelArrow,
			// Token: 0x0403695D RID: 223581
			PanelLevel,
			// Token: 0x0403695E RID: 223582
			DynScrollView,
			// Token: 0x0403695F RID: 223583
			ButtonScrollView,
			// Token: 0x04036960 RID: 223584
			AttributeContent,
			// Token: 0x04036961 RID: 223585
			AttributeSlotWider,
			// Token: 0x04036962 RID: 223586
			StrengthItem,
			// Token: 0x04036963 RID: 223587
			SoarStrengthItem
		}
	}
}
