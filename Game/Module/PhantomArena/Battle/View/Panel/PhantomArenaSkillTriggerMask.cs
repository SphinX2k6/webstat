using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Canvas;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Battle.SkillInteract;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055C3 RID: 21955
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaSkillTriggerMask : UiPanelBase, IAreaCanvas
	{
		// Token: 0x17008FDF RID: 36831
		// (get) Token: 0x06037EB8 RID: 229048 RVA: 0x00E2AF15 File Offset: 0x00E29115
		// (set) Token: 0x06037EB9 RID: 229049 RVA: 0x00E2AF1D File Offset: 0x00E2911D
		public bool IsInSkillInteract
		{
			get
			{
				return this.IsInSkillInteractInternal;
			}
			set
			{
				this.IsInSkillInteractInternal = value;
				ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
			}
		}

		// Token: 0x06037EBA RID: 229050 RVA: 0x00E2AF30 File Offset: 0x00E29130
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnConfirmClick)),
				new ValueTuple<int, Delegate>(6, new Action(this.OnCancelClick))
			};
		}

		// Token: 0x06037EBB RID: 229051 RVA: 0x00E2B01D File Offset: 0x00E2921D
		private void OnConfirmClick()
		{
			ISkillInteractMainUiInteract uiInteract = this.UiInteract;
			if (uiInteract == null)
			{
				return;
			}
			uiInteract.ReceiveClickData(ESkillInteractMainUiInteractType.ConfirmBtn, new object[0]);
		}

		// Token: 0x06037EBC RID: 229052 RVA: 0x00E2B037 File Offset: 0x00E29237
		private void OnCancelClick()
		{
			ISkillInteractMainUiInteract uiInteract = this.UiInteract;
			if (uiInteract == null)
			{
				return;
			}
			uiInteract.ReceiveClickData(ESkillInteractMainUiInteractType.CancelBtn, new object[0]);
		}

		// Token: 0x06037EBD RID: 229053 RVA: 0x00E2B051 File Offset: 0x00E29251
		protected override void OnStart()
		{
			this.ViewProxy.CanvasManager.AddAreaCanvas(this);
		}

		// Token: 0x06037EBE RID: 229054 RVA: 0x00E2B064 File Offset: 0x00E29264
		public void ShowTriggerMask(int? skillId)
		{
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(skillId != null);
			}
			this.SetActive(true);
			this.IsInSkillInteract = true;
		}

		// Token: 0x06037EBF RID: 229055 RVA: 0x00E2B08D File Offset: 0x00E2928D
		public void RefreshTips(int selectNum, int allNum)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "PhantomBattle_1068", new <>z__ReadOnlyArray<object>(new object[]
			{
				allNum,
				selectNum,
				allNum
			}));
		}

		// Token: 0x06037EC0 RID: 229056 RVA: 0x00E2B0CB File Offset: 0x00E292CB
		public void RefreshSkill(string skillName, string skillDesc, string[] paramsList)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), skillName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), skillDesc, paramsList);
		}

		// Token: 0x06037EC1 RID: 229057 RVA: 0x00E2B0F8 File Offset: 0x00E292F8
		public void RefreshCancelBtnActive(bool isPassive)
		{
			UUIButtonComponent button = base.GetButton(6);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(!isPassive);
		}

		// Token: 0x06037EC2 RID: 229058 RVA: 0x00E2B127 File Offset: 0x00E29327
		public void HideTriggerMask()
		{
			this.SetActive(false);
			this.IsInSkillInteract = false;
		}

		// Token: 0x06037EC3 RID: 229059 RVA: 0x00E2B137 File Offset: 0x00E29337
		public void RegisterViewProxy(PhantomArenaBattleProxy proxy)
		{
			this.ViewProxy = proxy;
		}

		// Token: 0x06037EC4 RID: 229060 RVA: 0x00E2B140 File Offset: 0x00E29340
		public bool CheckCanvasSortOrder(List<EPhantomArenaInteractTag> tagList, ISkillTriggerInfo skillTriggerInfo)
		{
			return true;
		}

		// Token: 0x06037EC5 RID: 229061 RVA: 0x00E2B143 File Offset: 0x00E29343
		public void HandleSortOrder()
		{
		}

		// Token: 0x06037EC6 RID: 229062 RVA: 0x00E2B145 File Offset: 0x00E29345
		public void CancelSortOrder()
		{
		}

		// Token: 0x06037EC7 RID: 229063 RVA: 0x00E2B147 File Offset: 0x00E29347
		[NullableContext(2)]
		public void ReceiveUiInteract(ISkillInteractMainUiInteract uiInteract)
		{
			this.UiInteract = uiInteract;
		}

		// Token: 0x0401FFE0 RID: 131040
		[Nullable(2)]
		private ISkillInteractMainUiInteract UiInteract;

		// Token: 0x0401FFE1 RID: 131041
		private PhantomArenaBattleProxy ViewProxy;

		// Token: 0x0401FFE2 RID: 131042
		private bool IsInSkillInteractInternal;

		// Token: 0x0200B5A5 RID: 46501
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403834F RID: 230223
			public const int ConfirmBtn = 0;

			// Token: 0x04038350 RID: 230224
			public const int SkillItem = 1;

			// Token: 0x04038351 RID: 230225
			public const int SkillName = 2;

			// Token: 0x04038352 RID: 230226
			public const int SkillDesc = 3;

			// Token: 0x04038353 RID: 230227
			public const int TipsItem = 4;

			// Token: 0x04038354 RID: 230228
			public const int Tips = 5;

			// Token: 0x04038355 RID: 230229
			public const int CancelBtn = 6;
		}
	}
}
