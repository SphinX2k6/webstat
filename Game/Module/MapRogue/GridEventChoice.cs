using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200592F RID: 22831
	[NullableContext(2)]
	[Nullable(0)]
	public class GridEventChoice : UiPanelBase, IEventStepItem
	{
		// Token: 0x17009444 RID: 37956
		// (get) Token: 0x06039EF1 RID: 237297 RVA: 0x00EA9F0E File Offset: 0x00EA810E
		// (set) Token: 0x06039EF2 RID: 237298 RVA: 0x00EA9F16 File Offset: 0x00EA8116
		public Action<int, int> ExecuteStep { get; set; }

		// Token: 0x17009445 RID: 37957
		// (get) Token: 0x06039EF3 RID: 237299 RVA: 0x00EA9F1F File Offset: 0x00EA811F
		public int StepId { get; }

		// Token: 0x17009446 RID: 37958
		// (get) Token: 0x06039EF4 RID: 237300 RVA: 0x00EA9F27 File Offset: 0x00EA8127
		public EStepType StepType { get; }

		// Token: 0x17009447 RID: 37959
		// (get) Token: 0x06039EF5 RID: 237301 RVA: 0x00EA9F2F File Offset: 0x00EA812F
		// (set) Token: 0x06039EF6 RID: 237302 RVA: 0x00EA9F37 File Offset: 0x00EA8137
		public Action<int, EStepType> CanInteractCallback { get; set; }

		// Token: 0x06039EF7 RID: 237303 RVA: 0x00EA9F40 File Offset: 0x00EA8140
		public GridEventChoice(int stepId, EStepType stepType = EStepType.Choose)
		{
			this.StepId = stepId;
			this.StepType = stepType;
		}

		// Token: 0x06039EF8 RID: 237304 RVA: 0x00EA9F64 File Offset: 0x00EA8164
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem))
			};
		}

		// Token: 0x06039EF9 RID: 237305 RVA: 0x00EAA02C File Offset: 0x00EA822C
		protected override UniTask OnBeforeStartAsync()
		{
			GridEventChoice.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GridEventChoice.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039EFA RID: 237306 RVA: 0x00EAA06F File Offset: 0x00EA826F
		protected override void OnStart()
		{
			this.ToggleLayout = new GenericLayout<GridEventChoiceToggle, IToggleItemData>(base.GetVerticalLayout(5), new Func<GridEventChoiceToggle>(this.OnCreateToggleItem), null, false, true);
		}

		// Token: 0x06039EFB RID: 237307 RVA: 0x00EAA094 File Offset: 0x00EA8294
		[NullableContext(1)]
		public UniTask Refresh(IList<EventOption> options)
		{
			GridEventChoice.<Refresh>d__22 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.options = options;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<GridEventChoice.<Refresh>d__22>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x06039EFC RID: 237308 RVA: 0x00EAA0E0 File Offset: 0x00EA82E0
		[NullableContext(1)]
		private void SetTitle(string tagId, [Nullable(2)] string tagColor = null)
		{
			UUIText text = base.GetText(2);
			UUISprite sprite = base.GetSprite(3);
			UUIItem item = base.GetItem(1);
			if (StringUtils.IsEmpty(tagId))
			{
				item.SetUIActive(false);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, tagId, Array.Empty<object>());
			if (tagColor != null)
			{
				FColor color = FColor.FromHex(tagColor);
				sprite.SetColor(color);
			}
			item.SetUIActive(true);
		}

		// Token: 0x06039EFD RID: 237309 RVA: 0x00EAA13E File Offset: 0x00EA833E
		public void MaskClick()
		{
		}

		// Token: 0x06039EFE RID: 237310 RVA: 0x00EAA140 File Offset: 0x00EA8340
		[NullableContext(1)]
		private GridEventChoiceToggle OnCreateToggleItem()
		{
			return new GridEventChoiceToggle
			{
				OnExtendToggleStateChanged = new Action<EToggleState, int>(this.OnExtendToggleStateChanged),
				OnCanExecuteChangeFunc = new Func<EToggleState, int, bool>(this.OnCanExecuteChangeFunc)
			};
		}

		// Token: 0x06039EFF RID: 237311 RVA: 0x00EAA16C File Offset: 0x00EA836C
		private void OnExtendToggleStateChanged(EToggleState state, int optionId)
		{
			if (state != EToggleState.ETT_UnChecked)
			{
				IToggleItemData data;
				if (!this.ToggleDataMap.TryGetValue(optionId, out data))
				{
					return;
				}
				this.FinishItemInstance.Refresh(data);
				UUIItem rootUiItem = this.ToggleLayout.GetRootUiItem();
				if (rootUiItem != null)
				{
					rootUiItem.SetUIActive(false);
				}
				this.FinishItemInstance.SetActive(true);
				Action<int, int> executeStep = this.ExecuteStep;
				if (executeStep == null)
				{
					return;
				}
				executeStep(this.StepId, optionId);
			}
		}

		// Token: 0x06039F00 RID: 237312 RVA: 0x00EAA1D3 File Offset: 0x00EA83D3
		private bool OnCanExecuteChangeFunc(EToggleState state, int optionId)
		{
			return this.CanInteract;
		}

		// Token: 0x04020D22 RID: 134434
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected GenericLayout<GridEventChoiceToggle, IToggleItemData> ToggleLayout;

		// Token: 0x04020D23 RID: 134435
		[Nullable(1)]
		protected Dictionary<int, IToggleItemData> ToggleDataMap = new Dictionary<int, IToggleItemData>();

		// Token: 0x04020D24 RID: 134436
		protected GridEventChoiceFinish FinishItemInstance;

		// Token: 0x04020D25 RID: 134437
		private bool CanInteract;
	}
}
