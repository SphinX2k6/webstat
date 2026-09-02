using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007009 RID: 28681
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonTouchUiEditContainer : ITouchUiEditContainer
	{
		// Token: 0x060456D8 RID: 284376 RVA: 0x01226E70 File Offset: 0x01225070
		public UniTask LoadPanel(UUIItem parent, string[] resIdList, CommonTouchUiEditGroup groupConfig)
		{
			CommonTouchUiEditContainer.<LoadPanel>d__2 <LoadPanel>d__;
			<LoadPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadPanel>d__.<>4__this = this;
			<LoadPanel>d__.parent = parent;
			<LoadPanel>d__.resIdList = resIdList;
			<LoadPanel>d__.groupConfig = groupConfig;
			<LoadPanel>d__.<>1__state = -1;
			<LoadPanel>d__.<>t__builder.Start<CommonTouchUiEditContainer.<LoadPanel>d__2>(ref <LoadPanel>d__);
			return <LoadPanel>d__.<>t__builder.Task;
		}

		// Token: 0x060456D9 RID: 284377 RVA: 0x01226ECC File Offset: 0x012250CC
		[return: Nullable(2)]
		public UUIItem GetItem(string resId, int index, int subPanelIndex)
		{
			UiPanelBase uiPanelBase;
			if (!this.PanelMap.TryGetValue(resId, out uiPanelBase))
			{
				return null;
			}
			AActor aactor = uiPanelBase.GetRootActor();
			ULGUIComponentsRegistry ulguicomponentsRegistry = this.GetLguiComponentsRegistry(uiPanelBase);
			if (ulguicomponentsRegistry == null)
			{
				return null;
			}
			if (subPanelIndex > -1)
			{
				AActor aactor2 = ulguicomponentsRegistry.Components.Get(subPanelIndex);
				if (aactor2 == null)
				{
					return null;
				}
				ULGUIComponentsRegistry ulguicomponentsRegistry2 = aactor2.GetComponentByClass(ULGUIComponentsRegistry.StaticClass()) as ULGUIComponentsRegistry;
				if (ulguicomponentsRegistry2 == null)
				{
					return null;
				}
				ulguicomponentsRegistry = ulguicomponentsRegistry2;
				aactor = aactor2;
			}
			if (index == -1)
			{
				return ((aactor != null) ? aactor.GetComponentByClass(UUIItem.StaticClass()) : null) as UUIItem;
			}
			AActor aactor3 = ulguicomponentsRegistry.Components.Get(index);
			if (aactor3 == null)
			{
				return null;
			}
			return aactor3.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
		}

		// Token: 0x060456DA RID: 284378 RVA: 0x01226F84 File Offset: 0x01225184
		public UUIItem[] GetRegistryItemList(string resId)
		{
			UiPanelBase panel;
			if (!this.PanelMap.TryGetValue(resId, out panel))
			{
				return new UUIItem[0];
			}
			ULGUIComponentsRegistry lguiComponentsRegistry = this.GetLguiComponentsRegistry(panel);
			if (lguiComponentsRegistry == null)
			{
				return new UUIItem[0];
			}
			List<UUIItem> list = new List<UUIItem>();
			for (int i = 0; i < lguiComponentsRegistry.Components.Num(); i++)
			{
				AActor aactor = lguiComponentsRegistry.Components.Get(i);
				if (aactor != null)
				{
					UUIItem uuiitem = aactor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
					if (uuiitem != null)
					{
						list.Add(uuiitem);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x060456DB RID: 284379 RVA: 0x01227012 File Offset: 0x01225212
		public UUIItem GetRootItem()
		{
			return this.RootPanel.GetRootItem();
		}

		// Token: 0x060456DC RID: 284380 RVA: 0x01227020 File Offset: 0x01225220
		public void OnViewDestroy()
		{
			foreach (UiPanelBase uiPanelBase in this.PanelMap.Values)
			{
				uiPanelBase.Destroy(null);
			}
			this.PanelMap.Clear();
			if (this.RootPanel != null)
			{
				this.RootPanel.Destroy(null);
			}
		}

		// Token: 0x060456DD RID: 284381 RVA: 0x01227098 File Offset: 0x01225298
		[return: Nullable(2)]
		private ULGUIComponentsRegistry GetLguiComponentsRegistry(UiPanelBase panel)
		{
			AActor rootActor = panel.GetRootActor();
			if (rootActor == null)
			{
				return null;
			}
			return rootActor.GetComponentByClass(ULGUIComponentsRegistry.StaticClass()) as ULGUIComponentsRegistry;
		}

		// Token: 0x04026CDC RID: 158940
		[Nullable(2)]
		private CommonTouchUiEditRootPanel RootPanel;

		// Token: 0x04026CDD RID: 158941
		private readonly Dictionary<string, UiPanelBase> PanelMap = new Dictionary<string, UiPanelBase>();
	}
}
