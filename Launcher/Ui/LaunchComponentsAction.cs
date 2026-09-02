using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Ui.HotFix;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui
{
	// Token: 0x020044F6 RID: 17654
	[NullableContext(2)]
	[Nullable(0)]
	public class LaunchComponentsAction
	{
		// Token: 0x0602E875 RID: 190581 RVA: 0x00B065A3 File Offset: 0x00B047A3
		protected virtual void OnStart()
		{
		}

		// Token: 0x0602E876 RID: 190582 RVA: 0x00B065A5 File Offset: 0x00B047A5
		protected virtual void OnBeforeDestroy()
		{
		}

		// Token: 0x0602E877 RID: 190583 RVA: 0x00B065A7 File Offset: 0x00B047A7
		[NullableContext(1)]
		public void SetRootActorLaunchComponentsAction(AActor actor)
		{
			this.InitRootActor(actor);
			this.InitSequencePlayer();
			this.CheckHasRegistry();
			this.OnStart();
		}

		// Token: 0x0602E878 RID: 190584 RVA: 0x00B065C2 File Offset: 0x00B047C2
		[NullableContext(1)]
		private void InitRootActor(AActor actor)
		{
			this.RootActor = actor;
			this.RootItem = (actor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
		}

		// Token: 0x0602E879 RID: 190585 RVA: 0x00B065E6 File Offset: 0x00B047E6
		private void InitSequencePlayer()
		{
			this.SequencePlayer = new HotFixSequencePlayer(this.RootItem);
		}

		// Token: 0x0602E87A RID: 190586 RVA: 0x00B065F9 File Offset: 0x00B047F9
		private void CheckHasRegistry()
		{
			this.ComponentsRegistry = (this.RootActor.GetComponentByClass(ULGUIComponentsRegistry.StaticClass()) as ULGUIComponentsRegistry);
			if (this.ComponentsRegistry != null)
			{
				this.ComponentsRegistry.TsClassName = base.GetType().Name;
			}
		}

		// Token: 0x0602E87B RID: 190587 RVA: 0x00B06639 File Offset: 0x00B04839
		[NullableContext(1)]
		public TChildComponentAction GetElement<[Nullable(0)] TChildComponentAction>(int index) where TChildComponentAction : LaunchComponentsAction
		{
			return (TChildComponentAction)((object)this.ElementMap[index]);
		}

		// Token: 0x0602E87C RID: 190588 RVA: 0x00B0664C File Offset: 0x00B0484C
		protected UUIItem GetItem(int index)
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent != null)
			{
				return actorFromRegistryComponent.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
			}
			return null;
		}

		// Token: 0x0602E87D RID: 190589 RVA: 0x00B0667C File Offset: 0x00B0487C
		protected UUITexture GetTexture(int index)
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent != null)
			{
				return actorFromRegistryComponent.GetComponentByClass(UUITexture.StaticClass()) as UUITexture;
			}
			return null;
		}

		// Token: 0x0602E87E RID: 190590 RVA: 0x00B066AC File Offset: 0x00B048AC
		protected UUIText GetText(int index)
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent != null)
			{
				return actorFromRegistryComponent.GetComponentByClass(UUIText.StaticClass()) as UUIText;
			}
			return null;
		}

		// Token: 0x0602E87F RID: 190591 RVA: 0x00B066DC File Offset: 0x00B048DC
		protected UUIButtonComponent GetButton(int index)
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent != null)
			{
				return actorFromRegistryComponent.GetComponentByClass(UUIButtonComponent.StaticClass()) as UUIButtonComponent;
			}
			return null;
		}

		// Token: 0x0602E880 RID: 190592 RVA: 0x00B0670C File Offset: 0x00B0490C
		protected UUIExtendToggle GetExtendToggle(int index)
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent != null)
			{
				return actorFromRegistryComponent.GetComponentByClass(UUIExtendToggle.StaticClass()) as UUIExtendToggle;
			}
			return null;
		}

		// Token: 0x0602E881 RID: 190593 RVA: 0x00B0673C File Offset: 0x00B0493C
		protected UUILayoutBase GetLayout(int index)
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent != null)
			{
				return actorFromRegistryComponent.GetComponentByClass(UUILayoutBase.StaticClass()) as UUILayoutBase;
			}
			return null;
		}

		// Token: 0x0602E882 RID: 190594 RVA: 0x00B0676C File Offset: 0x00B0496C
		protected UUIDynScrollViewComponent GetUIDynScrollViewComponent(int index)
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent != null)
			{
				return actorFromRegistryComponent.GetComponentByClass(UUIDynScrollViewComponent.StaticClass()) as UUIDynScrollViewComponent;
			}
			return null;
		}

		// Token: 0x0602E883 RID: 190595 RVA: 0x00B0679C File Offset: 0x00B0499C
		protected UUIScrollViewWithScrollbarComponent GetUiScrollViewWithScrollBar(int index)
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent != null)
			{
				return actorFromRegistryComponent.GetComponentByClass(UUIScrollViewWithScrollbarComponent.StaticClass()) as UUIScrollViewWithScrollbarComponent;
			}
			return null;
		}

		// Token: 0x0602E884 RID: 190596 RVA: 0x00B067CC File Offset: 0x00B049CC
		protected UUIScrollbarComponent GetUiScrollbarComponent(int index)
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent != null)
			{
				return actorFromRegistryComponent.GetComponentByClass(UUIScrollbarComponent.StaticClass()) as UUIScrollbarComponent;
			}
			return null;
		}

		// Token: 0x0602E885 RID: 190597 RVA: 0x00B067FB File Offset: 0x00B049FB
		private AActor GetActorFromRegistryComponent(int index)
		{
			if (this.ComponentsRegistry == null || index >= this.ComponentsRegistry.Components.Num())
			{
				return null;
			}
			return this.ComponentsRegistry.Components.Get(index);
		}

		// Token: 0x0602E886 RID: 190598 RVA: 0x00B0682C File Offset: 0x00B04A2C
		public void SetActive(bool visibility)
		{
			if (this.RootItem == null || !this.RootItem.IsValid())
			{
				return;
			}
			bool flag = this.RootItem.IsUIActiveSelf();
			this.RootItem.SetUIActive(visibility);
			if (flag != visibility)
			{
				if (visibility)
				{
					this.OnShow();
					return;
				}
				this.OnHide();
			}
		}

		// Token: 0x0602E887 RID: 190599 RVA: 0x00B06879 File Offset: 0x00B04A79
		protected virtual void OnShow()
		{
		}

		// Token: 0x0602E888 RID: 190600 RVA: 0x00B0687B File Offset: 0x00B04A7B
		protected virtual void OnHide()
		{
		}

		// Token: 0x0602E889 RID: 190601 RVA: 0x00B0687D File Offset: 0x00B04A7D
		public UUIItem GetRootItem()
		{
			return this.RootItem;
		}

		// Token: 0x17008040 RID: 32832
		// (get) Token: 0x0602E88A RID: 190602 RVA: 0x00B06885 File Offset: 0x00B04A85
		protected bool IsClear
		{
			get
			{
				return this.IsClearData;
			}
		}

		// Token: 0x0602E88B RID: 190603 RVA: 0x00B06890 File Offset: 0x00B04A90
		[NullableContext(0)]
		[return: Nullable(2)]
		public TChildComponentAction AttachElement<TChildComponentAction>(int index) where TChildComponentAction : LaunchComponentsAction, new()
		{
			AActor actorFromRegistryComponent = this.GetActorFromRegistryComponent(index);
			if (actorFromRegistryComponent == null)
			{
				return default(TChildComponentAction);
			}
			TChildComponentAction tchildComponentAction = Activator.CreateInstance<TChildComponentAction>();
			tchildComponentAction.SetRootActorLaunchComponentsAction(actorFromRegistryComponent);
			this.ElementMap[index] = tchildComponentAction;
			return tchildComponentAction;
		}

		// Token: 0x0602E88C RID: 190604 RVA: 0x00B068D8 File Offset: 0x00B04AD8
		[NullableContext(1)]
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<TChildComponentAction> AttachElementAsyncFromPath<[Nullable(0)] TChildComponentAction>(int index, string path) where TChildComponentAction : LaunchComponentsAction, new()
		{
			LaunchComponentsAction.<AttachElementAsyncFromPath>d__30<TChildComponentAction> <AttachElementAsyncFromPath>d__;
			<AttachElementAsyncFromPath>d__.<>t__builder = AsyncUniTaskMethodBuilder<TChildComponentAction>.Create();
			<AttachElementAsyncFromPath>d__.<>4__this = this;
			<AttachElementAsyncFromPath>d__.index = index;
			<AttachElementAsyncFromPath>d__.path = path;
			<AttachElementAsyncFromPath>d__.<>1__state = -1;
			<AttachElementAsyncFromPath>d__.<>t__builder.Start<LaunchComponentsAction.<AttachElementAsyncFromPath>d__30<TChildComponentAction>>(ref <AttachElementAsyncFromPath>d__);
			return <AttachElementAsyncFromPath>d__.<>t__builder.Task;
		}

		// Token: 0x0602E88D RID: 190605 RVA: 0x00B0692B File Offset: 0x00B04B2B
		public bool DestroyTemp()
		{
			if (this.IsClearData)
			{
				return false;
			}
			this.OnBeforeDestroy();
			this.ClearElementMap();
			this.ClearSequencePlayer();
			this.IsClearData = true;
			return true;
		}

		// Token: 0x0602E88E RID: 190606 RVA: 0x00B06954 File Offset: 0x00B04B54
		private void ClearElementMap()
		{
			foreach (KeyValuePair<int, LaunchComponentsAction> keyValuePair in this.ElementMap)
			{
				keyValuePair.Value.Destroy();
			}
			this.ElementMap.Clear();
		}

		// Token: 0x0602E88F RID: 190607 RVA: 0x00B069B8 File Offset: 0x00B04BB8
		private void ClearSequencePlayer()
		{
			HotFixSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.ClearSequence();
		}

		// Token: 0x0602E890 RID: 190608 RVA: 0x00B069CA File Offset: 0x00B04BCA
		public virtual void Destroy()
		{
			this.DestroyTemp();
			if (this.RootActor != null)
			{
				ULGUIBPLibrary.DestroyActorWithHierarchy(this.RootActor, true);
			}
			this.RootActor = null;
			this.RootItem = null;
		}

		// Token: 0x0401A6F8 RID: 108280
		private bool IsClearData;

		// Token: 0x0401A6F9 RID: 108281
		protected UUIItem RootItem;

		// Token: 0x0401A6FA RID: 108282
		protected AActor RootActor;

		// Token: 0x0401A6FB RID: 108283
		private ULGUIComponentsRegistry ComponentsRegistry;

		// Token: 0x0401A6FC RID: 108284
		[Nullable(1)]
		protected Dictionary<int, LaunchComponentsAction> ElementMap = new Dictionary<int, LaunchComponentsAction>();

		// Token: 0x0401A6FD RID: 108285
		protected HotFixSequencePlayer SequencePlayer;
	}
}
