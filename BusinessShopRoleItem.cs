using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.MoonChasing;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013DA RID: 5082
public class BusinessShopRoleItem : GridProxyAbstract<int>
{
	// Token: 0x06008C7F RID: 35967 RVA: 0x0024F014 File Offset: 0x0024D214
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(USpineSkeletonAnimationComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06008C80 RID: 35968 RVA: 0x0024F084 File Offset: 0x0024D284
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(1);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(false);
	}

	// Token: 0x06008C81 RID: 35969 RVA: 0x0024F098 File Offset: 0x0024D298
	public void SwitchRoleSpineAnim(ESpineAnimation animName, float mixDuration)
	{
		UTrackEntry utrackEntry = base.GetSpine(0).SetAnimation(0, animName.ToString(), true);
		if (utrackEntry == null)
		{
			return;
		}
		utrackEntry.SetMixDuration(mixDuration);
	}

	// Token: 0x06008C82 RID: 35970 RVA: 0x0024F0C0 File Offset: 0x0024D2C0
	public override void Refresh(int roleId, bool isSelected, int gridIndex)
	{
		this.Refresh(roleId);
	}

	// Token: 0x06008C83 RID: 35971 RVA: 0x0024F0C9 File Offset: 0x0024D2C9
	public void Refresh(int roleId)
	{
		this.RoleId = roleId;
	}

	// Token: 0x06008C84 RID: 35972 RVA: 0x0024F0D4 File Offset: 0x0024D2D4
	public UniTask RefreshAsync()
	{
		BusinessShopRoleItem.<RefreshAsync>d__7 <RefreshAsync>d__;
		<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshAsync>d__.<>4__this = this;
		<RefreshAsync>d__.<>1__state = -1;
		<RefreshAsync>d__.<>t__builder.Start<BusinessShopRoleItem.<RefreshAsync>d__7>(ref <RefreshAsync>d__);
		return <RefreshAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008C85 RID: 35973 RVA: 0x0024F117 File Offset: 0x0024D317
	[NullableContext(1)]
	public void ShowDialog(string textId)
	{
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, Array.Empty<object>());
	}

	// Token: 0x0400417C RID: 16764
	protected int RoleId;

	// Token: 0x020077B4 RID: 30644
	private static class ERoleItem
	{
		// Token: 0x04029329 RID: 168745
		public const int RoleSpine = 0;

		// Token: 0x0402932A RID: 168746
		public const int DialogItem = 1;

		// Token: 0x0402932B RID: 168747
		public const int Dialog = 2;

		// Token: 0x0402932C RID: 168748
		public const int SpineItem = 3;
	}
}
