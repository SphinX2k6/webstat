using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005937 RID: 22839
	[NullableContext(2)]
	[Nullable(0)]
	public class GridEventCompEnding : UiPanelBase, IEventStepItem
	{
		// Token: 0x1700944C RID: 37964
		// (get) Token: 0x06039F1C RID: 237340 RVA: 0x00EAA98A File Offset: 0x00EA8B8A
		public int StepId { get; }

		// Token: 0x1700944D RID: 37965
		// (get) Token: 0x06039F1D RID: 237341 RVA: 0x00EAA992 File Offset: 0x00EA8B92
		public EStepType StepType { get; }

		// Token: 0x1700944E RID: 37966
		// (get) Token: 0x06039F1E RID: 237342 RVA: 0x00EAA99A File Offset: 0x00EA8B9A
		// (set) Token: 0x06039F1F RID: 237343 RVA: 0x00EAA9A2 File Offset: 0x00EA8BA2
		public Action<int, EStepType> CanInteractCallback { get; set; }

		// Token: 0x1700944F RID: 37967
		// (get) Token: 0x06039F20 RID: 237344 RVA: 0x00EAA9AB File Offset: 0x00EA8BAB
		// (set) Token: 0x06039F21 RID: 237345 RVA: 0x00EAA9B3 File Offset: 0x00EA8BB3
		public Action<int, int> ExecuteStep { get; set; }

		// Token: 0x06039F22 RID: 237346 RVA: 0x00EAA9BC File Offset: 0x00EA8BBC
		public GridEventCompEnding(int stepId, EStepType stepType = EStepType.Ending)
		{
			this.StepId = stepId;
			this.StepType = stepType;
		}

		// Token: 0x06039F23 RID: 237347 RVA: 0x00EAA9D4 File Offset: 0x00EA8BD4
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06039F24 RID: 237348 RVA: 0x00EAAA30 File Offset: 0x00EA8C30
		public void Refresh()
		{
			RogueResEventStep? rogueEventStepById = ConfigBase<MapRogueConfig>.Instance.GetRogueEventStepById(this.StepId);
			if (rogueEventStepById == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueEventStepById.Value.TitleKey, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), rogueEventStepById.Value.TextKey, Array.Empty<object>());
			Action<int, EStepType> canInteractCallback = this.CanInteractCallback;
			if (canInteractCallback == null)
			{
				return;
			}
			canInteractCallback(this.StepId, this.StepType);
		}

		// Token: 0x06039F25 RID: 237349 RVA: 0x00EAAABE File Offset: 0x00EA8CBE
		public void MaskClick()
		{
		}
	}
}
