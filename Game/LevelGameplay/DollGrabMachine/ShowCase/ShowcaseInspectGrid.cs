using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.ShowCase
{
	// Token: 0x02006EE6 RID: 28390
	internal class ShowcaseInspectGrid : UiPanelBase
	{
		// Token: 0x06044D1B RID: 281883 RVA: 0x011E7A08 File Offset: 0x011E5C08
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnPreview));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044D1C RID: 281884 RVA: 0x011E7A8D File Offset: 0x011E5C8D
		protected override void OnStart()
		{
			this.InitTransform();
		}

		// Token: 0x06044D1D RID: 281885 RVA: 0x011E7A98 File Offset: 0x011E5C98
		public void InitTransform()
		{
			UUIItem rootItem = this.RootItem;
			if (((rootItem != null) ? rootItem.GetCanvasScaler() : null) == null)
			{
				return;
			}
			DollItemInfo dollItemInfo = this.DollItemInfo;
			BP_DollShowCaseActor_C bp_DollShowCaseActor_C = (dollItemInfo != null) ? dollItemInfo.DollShowCaseActor : null;
			if (bp_DollShowCaseActor_C == null || !bp_DollShowCaseActor_C.IsValid())
			{
				return;
			}
			Vector vector = Vector.Create();
			Singleton<LguiUtil>.Instance.ConvertSceneActorPositionToLguiPosition(bp_DollShowCaseActor_C, vector);
			UUIItem rootItem2 = this.RootItem;
			FVector fvector = vector.ToUeVectorOld();
			rootItem2.SetUIWorldLocation(fvector);
		}

		// Token: 0x06044D1E RID: 281886 RVA: 0x011E7AFF File Offset: 0x011E5CFF
		[NullableContext(1)]
		public void SetDollItemInfo(DollItemInfo dollItemInfo)
		{
			this.DollItemInfo = dollItemInfo;
		}

		// Token: 0x06044D1F RID: 281887 RVA: 0x011E7B08 File Offset: 0x011E5D08
		private void OnPreview()
		{
			if (this.DollItemInfo != null)
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.DollGrabShowcaseFocusView, this.DollItemInfo, null);
			}
		}

		// Token: 0x0402653C RID: 156988
		[Nullable(2)]
		private DollItemInfo DollItemInfo;
	}
}
