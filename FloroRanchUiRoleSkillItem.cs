using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C78 RID: 7288
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchUiRoleSkillItem : FloroRanchUiItemBase
{
	// Token: 0x0600D4E2 RID: 54498 RVA: 0x0038D114 File Offset: 0x0038B314
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickSkillButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D4E3 RID: 54499 RVA: 0x0038D260 File Offset: 0x0038B460
	protected override UniTask OnBeforeStartAsync()
	{
		FloroRanchUiRoleSkillItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FloroRanchUiRoleSkillItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4E4 RID: 54500 RVA: 0x0038D2A4 File Offset: 0x0038B4A4
	public override UniTask PlayShowAnim()
	{
		FloroRanchUiRoleSkillItem.<PlayShowAnim>d__5 <PlayShowAnim>d__;
		<PlayShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayShowAnim>d__.<>4__this = this;
		<PlayShowAnim>d__.<>1__state = -1;
		<PlayShowAnim>d__.<>t__builder.Start<FloroRanchUiRoleSkillItem.<PlayShowAnim>d__5>(ref <PlayShowAnim>d__);
		return <PlayShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4E5 RID: 54501 RVA: 0x0038D2E8 File Offset: 0x0038B4E8
	public override UniTask PlaySkillAnim()
	{
		FloroRanchUiRoleSkillItem.<PlaySkillAnim>d__6 <PlaySkillAnim>d__;
		<PlaySkillAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySkillAnim>d__.<>4__this = this;
		<PlaySkillAnim>d__.<>1__state = -1;
		<PlaySkillAnim>d__.<>t__builder.Start<FloroRanchUiRoleSkillItem.<PlaySkillAnim>d__6>(ref <PlaySkillAnim>d__);
		return <PlaySkillAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4E6 RID: 54502 RVA: 0x0038D32C File Offset: 0x0038B52C
	public override UniTask PlayHideAnim()
	{
		FloroRanchUiRoleSkillItem.<PlayHideAnim>d__7 <PlayHideAnim>d__;
		<PlayHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideAnim>d__.<>4__this = this;
		<PlayHideAnim>d__.<>1__state = -1;
		<PlayHideAnim>d__.<>t__builder.Start<FloroRanchUiRoleSkillItem.<PlayHideAnim>d__7>(ref <PlayHideAnim>d__);
		return <PlayHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4E7 RID: 54503 RVA: 0x0038D36F File Offset: 0x0038B56F
	public override void Pause()
	{
		base.GetSpine(1).SetTimeScale(0f);
	}

	// Token: 0x0600D4E8 RID: 54504 RVA: 0x0038D382 File Offset: 0x0038B582
	public override void Resume()
	{
		base.GetSpine(1).SetTimeScale(1f);
	}

	// Token: 0x0600D4E9 RID: 54505 RVA: 0x0038D398 File Offset: 0x0038B598
	public override UniTask RefreshItem()
	{
		FloroRanchUiRoleSkillItem.<RefreshItem>d__10 <RefreshItem>d__;
		<RefreshItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshItem>d__.<>4__this = this;
		<RefreshItem>d__.<>1__state = -1;
		<RefreshItem>d__.<>t__builder.Start<FloroRanchUiRoleSkillItem.<RefreshItem>d__10>(ref <RefreshItem>d__);
		return <RefreshItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4EA RID: 54506 RVA: 0x0038D3DB File Offset: 0x0038B5DB
	public override FTransform? GetRewardPopTransform()
	{
		return new FTransform?(base.GetItem(5).GetOwner().GetTransform());
	}

	// Token: 0x0600D4EB RID: 54507 RVA: 0x0038D3F3 File Offset: 0x0038B5F3
	public void BindClickSkillCallback(Action<FloroRanchEntityBase> callback)
	{
		this.OnClickSkillCallback = callback;
	}

	// Token: 0x0600D4EC RID: 54508 RVA: 0x0038D3FC File Offset: 0x0038B5FC
	private void OnClickSkillButton()
	{
		Action<FloroRanchEntityBase> onClickSkillCallback = this.OnClickSkillCallback;
		if (onClickSkillCallback == null)
		{
			return;
		}
		onClickSkillCallback(this.Entity);
	}

	// Token: 0x04006536 RID: 25910
	private FloroRanchEntityDebugInfoItem DebugInfoItem;

	// Token: 0x04006537 RID: 25911
	private Action<FloroRanchEntityBase> OnClickSkillCallback = delegate(FloroRanchEntityBase entity)
	{
	};

	// Token: 0x02007FB7 RID: 32695
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402B791 RID: 178065
		public const int SkillChatText = 0;

		// Token: 0x0402B792 RID: 178066
		public const int RoleSpine = 1;

		// Token: 0x0402B793 RID: 178067
		public const int RemainUseTimeText = 2;

		// Token: 0x0402B794 RID: 178068
		public const int RoleSkillButton = 3;

		// Token: 0x0402B795 RID: 178069
		public const int SkillIconTexture = 4;

		// Token: 0x0402B796 RID: 178070
		public const int RoleRootItem = 5;

		// Token: 0x0402B797 RID: 178071
		public const int ActiveNiagara = 6;
	}
}
