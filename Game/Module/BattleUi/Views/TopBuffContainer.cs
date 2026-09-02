using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200611B RID: 24859
	[NullableContext(1)]
	[Nullable(0)]
	public class TopBuffContainer
	{
		// Token: 0x0603ECBE RID: 257214 RVA: 0x01014E0C File Offset: 0x0101300C
		public UniTask InitAsync(UUIItem parentItem, BattleUiRoleData roleData)
		{
			TopBuffContainer.<InitAsync>d__3 <InitAsync>d__;
			<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.parentItem = parentItem;
			<InitAsync>d__.roleData = roleData;
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<TopBuffContainer.<InitAsync>d__3>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603ECBF RID: 257215 RVA: 0x01014E5F File Offset: 0x0101305F
		public virtual void SetVisible(bool visible)
		{
		}

		// Token: 0x0603ECC0 RID: 257216 RVA: 0x01014E61 File Offset: 0x01013061
		public virtual void Tick(float delta)
		{
		}

		// Token: 0x0603ECC1 RID: 257217 RVA: 0x01014E63 File Offset: 0x01013063
		public void Destroy()
		{
			this.ClearAllTagCountChangedCallback();
			this.OnDestroy();
		}

		// Token: 0x0603ECC2 RID: 257218 RVA: 0x01014E71 File Offset: 0x01013071
		protected virtual UniTask OnInitAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0603ECC3 RID: 257219 RVA: 0x01014E78 File Offset: 0x01013078
		protected virtual void OnDestroy()
		{
		}

		// Token: 0x0603ECC4 RID: 257220 RVA: 0x01014E7C File Offset: 0x0101307C
		protected void ListenForTagCountChanged(int tagId, BaseTagComponent.TTagChangedCallback onTagCountChange)
		{
			BattleUiRoleData roleData = this.RoleData;
			ITagTask tagTask;
			if (roleData == null)
			{
				tagTask = null;
			}
			else
			{
				BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
				tagTask = ((gameplayTagComponent != null) ? gameplayTagComponent.ListenForTagAnyCountChanged(tagId, onTagCountChange) : null);
			}
			ITagTask tagTask2 = tagTask;
			if (tagTask2 != null)
			{
				this.TagTaskList.Add(tagTask2);
			}
		}

		// Token: 0x0603ECC5 RID: 257221 RVA: 0x01014EBC File Offset: 0x010130BC
		protected void ListenForTagAddOrRemoveChanged(int tagId, BaseTagComponent.TTagSwitchedCallback onTagChange)
		{
			BattleUiRoleData roleData = this.RoleData;
			ITagTask tagTask;
			if (roleData == null)
			{
				tagTask = null;
			}
			else
			{
				BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
				tagTask = ((gameplayTagComponent != null) ? gameplayTagComponent.ListenForTagAddOrRemove(new int?(tagId), onTagChange, null) : null);
			}
			ITagTask tagTask2 = tagTask;
			if (tagTask2 != null)
			{
				this.TagTaskList.Add(tagTask2);
			}
		}

		// Token: 0x0603ECC6 RID: 257222 RVA: 0x01014F00 File Offset: 0x01013100
		private void ClearAllTagCountChangedCallback()
		{
			foreach (ITagTask tagTask in this.TagTaskList)
			{
				tagTask.EndTask();
			}
			this.TagTaskList.Clear();
		}

		// Token: 0x0402338B RID: 144267
		[Nullable(2)]
		protected UUIItem ParentItem;

		// Token: 0x0402338C RID: 144268
		[Nullable(2)]
		protected BattleUiRoleData RoleData;

		// Token: 0x0402338D RID: 144269
		protected readonly List<ITagTask> TagTaskList = new List<ITagTask>();
	}
}
