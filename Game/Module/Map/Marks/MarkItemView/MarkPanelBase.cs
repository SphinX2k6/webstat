using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Container;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Marks.MarkItemView
{
	// Token: 0x02005879 RID: 22649
	[NullableContext(2)]
	[Nullable(0)]
	public class MarkPanelBase : UiPanelBase
	{
		// Token: 0x170092FF RID: 37631
		// (get) Token: 0x0603997A RID: 235898 RVA: 0x00E9C448 File Offset: 0x00E9A648
		public UniTaskCompletionSource LoadingPromise
		{
			get
			{
				return this.LoadingTaskCompletionSource;
			}
		}

		// Token: 0x0603997B RID: 235899 RVA: 0x00E9C450 File Offset: 0x00E9A650
		public MarkPanelBase()
		{
			base.SkipDestroyActor = true;
		}

		// Token: 0x0603997C RID: 235900 RVA: 0x00E9C460 File Offset: 0x00E9A660
		[NullableContext(1)]
		public UniTask CreateByPoolResourceIdAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null)
		{
			MarkPanelBase.<CreateByPoolResourceIdAsync>d__7 <CreateByPoolResourceIdAsync>d__;
			<CreateByPoolResourceIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateByPoolResourceIdAsync>d__.<>4__this = this;
			<CreateByPoolResourceIdAsync>d__.resourceId = resourceId;
			<CreateByPoolResourceIdAsync>d__.parentItem = parentItem;
			<CreateByPoolResourceIdAsync>d__.<>1__state = -1;
			<CreateByPoolResourceIdAsync>d__.<>t__builder.Start<MarkPanelBase.<CreateByPoolResourceIdAsync>d__7>(ref <CreateByPoolResourceIdAsync>d__);
			return <CreateByPoolResourceIdAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603997D RID: 235901 RVA: 0x00E9C4B4 File Offset: 0x00E9A6B4
		[NullableContext(1)]
		public UniTask CreateThenShowByPoolResourceIdAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null)
		{
			MarkPanelBase.<CreateThenShowByPoolResourceIdAsync>d__8 <CreateThenShowByPoolResourceIdAsync>d__;
			<CreateThenShowByPoolResourceIdAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateThenShowByPoolResourceIdAsync>d__.<>4__this = this;
			<CreateThenShowByPoolResourceIdAsync>d__.resourceId = resourceId;
			<CreateThenShowByPoolResourceIdAsync>d__.parentItem = parentItem;
			<CreateThenShowByPoolResourceIdAsync>d__.<>1__state = -1;
			<CreateThenShowByPoolResourceIdAsync>d__.<>t__builder.Start<MarkPanelBase.<CreateThenShowByPoolResourceIdAsync>d__8>(ref <CreateThenShowByPoolResourceIdAsync>d__);
			return <CreateThenShowByPoolResourceIdAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603997E RID: 235902 RVA: 0x00E9C508 File Offset: 0x00E9A708
		[NullableContext(1)]
		private UniTask CreatePoolActorAsync(string resourceId, [Nullable(2)] UUIItem parentItem = null)
		{
			MarkPanelBase.<CreatePoolActorAsync>d__9 <CreatePoolActorAsync>d__;
			<CreatePoolActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreatePoolActorAsync>d__.<>4__this = this;
			<CreatePoolActorAsync>d__.resourceId = resourceId;
			<CreatePoolActorAsync>d__.parentItem = parentItem;
			<CreatePoolActorAsync>d__.<>1__state = -1;
			<CreatePoolActorAsync>d__.<>t__builder.Start<MarkPanelBase.<CreatePoolActorAsync>d__9>(ref <CreatePoolActorAsync>d__);
			return <CreatePoolActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603997F RID: 235903 RVA: 0x00E9C55B File Offset: 0x00E9A75B
		protected void DoRegisterEvents()
		{
			if (this.EventRegistered)
			{
				return;
			}
			this.EventRegistered = true;
			this.RegisterEvents();
		}

		// Token: 0x06039980 RID: 235904 RVA: 0x00E9C573 File Offset: 0x00E9A773
		protected void DoUnRegisterEvents()
		{
			if (!this.EventRegistered)
			{
				return;
			}
			this.EventRegistered = false;
			this.UnRegisterEvents();
		}

		// Token: 0x06039981 RID: 235905 RVA: 0x00E9C58B File Offset: 0x00E9A78B
		public virtual void RegisterEvents()
		{
		}

		// Token: 0x06039982 RID: 235906 RVA: 0x00E9C58D File Offset: 0x00E9A78D
		public virtual void UnRegisterEvents()
		{
		}

		// Token: 0x06039983 RID: 235907 RVA: 0x00E9C58F File Offset: 0x00E9A78F
		public virtual void RecycleToPool()
		{
			this.DoUnRegisterEvents();
			this.RecycleToPoolAsync();
		}

		// Token: 0x06039984 RID: 235908 RVA: 0x00E9C5A0 File Offset: 0x00E9A7A0
		private UniTask RecycleToPoolAsync()
		{
			MarkPanelBase.<RecycleToPoolAsync>d__16 <RecycleToPoolAsync>d__;
			<RecycleToPoolAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RecycleToPoolAsync>d__.<>4__this = this;
			<RecycleToPoolAsync>d__.<>1__state = -1;
			<RecycleToPoolAsync>d__.<>t__builder.Start<MarkPanelBase.<RecycleToPoolAsync>d__16>(ref <RecycleToPoolAsync>d__);
			return <RecycleToPoolAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039985 RID: 235909 RVA: 0x00E9C5E3 File Offset: 0x00E9A7E3
		protected override void OnAfterHide()
		{
			MarkSpritePool.UnRef(this.ComponentId);
		}

		// Token: 0x06039986 RID: 235910 RVA: 0x00E9C5F0 File Offset: 0x00E9A7F0
		[NullableContext(1)]
		protected override void SetSpriteByPath(string path, UUISprite uiSprite, bool setSize, EUiViewName? syncLoadViewName = null, [Nullable(2)] Action<bool> callback = null)
		{
			if (string.IsNullOrEmpty(path))
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
				return;
			}
			else
			{
				ULGUISpriteData_BaseObject ulguispriteData_BaseObject = MarkSpritePool.Get(this.ComponentId, path);
				if (ulguispriteData_BaseObject == null || !ulguispriteData_BaseObject.IsValid())
				{
					base.SetSpriteByPath(path, uiSprite, setSize, syncLoadViewName, delegate(bool result)
					{
						if (result)
						{
							MarkSpritePool.Ref(this.ComponentId, path, uiSprite.GetSprite());
						}
						if (callback != null)
						{
							callback(result);
						}
					});
					return;
				}
				uiSprite.SetSprite(ulguispriteData_BaseObject, setSize);
				Action<bool> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(true);
				return;
			}
		}

		// Token: 0x06039987 RID: 235911 RVA: 0x00E9C6A2 File Offset: 0x00E9A8A2
		public void SetVisible(bool visible)
		{
			if (visible)
			{
				this.RestoreLastVisiblePosition();
				UUIItem rootItem = this.RootItem;
				if (rootItem == null || !rootItem.bIsUIActive)
				{
					base.SetUiActive(true);
					return;
				}
			}
			else
			{
				this.SaveLastVisiblePosition();
				this.RootItem.SetAnchorOffsetX(2.1474836E+09f);
			}
		}

		// Token: 0x06039988 RID: 235912 RVA: 0x00E9C6E2 File Offset: 0x00E9A8E2
		private void SaveLastVisiblePosition()
		{
			this.LastVisibleAnchorOffsetX = new float?(this.RootItem.GetAnchorOffsetX());
		}

		// Token: 0x06039989 RID: 235913 RVA: 0x00E9C6FA File Offset: 0x00E9A8FA
		private void RestoreLastVisiblePosition()
		{
			if (this.LastVisibleAnchorOffsetX != null)
			{
				this.RootItem.SetAnchorOffsetX(this.LastVisibleAnchorOffsetX.Value);
			}
		}

		// Token: 0x04020ACD RID: 133837
		private UiPoolActor MarkItemActor;

		// Token: 0x04020ACE RID: 133838
		private string ResourceId;

		// Token: 0x04020ACF RID: 133839
		protected UniTaskCompletionSource LoadingTaskCompletionSource;

		// Token: 0x04020AD0 RID: 133840
		private float? LastVisibleAnchorOffsetX;

		// Token: 0x04020AD1 RID: 133841
		private bool EventRegistered;
	}
}
