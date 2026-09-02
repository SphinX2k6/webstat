using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026C2 RID: 9922
[NullableContext(1)]
[Nullable(0)]
public class QuestTreeDetailImageItem : UiPanelBase
{
	// Token: 0x06013926 RID: 80166 RVA: 0x005759F9 File Offset: 0x00573BF9
	public QuestTreeDetailImageItem(QuestTreeNodeData data)
	{
	}

	// Token: 0x06013927 RID: 80167 RVA: 0x00575A08 File Offset: 0x00573C08
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickImage));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013928 RID: 80168 RVA: 0x00575B34 File Offset: 0x00573D34
	protected override UniTask OnBeforeStartAsync()
	{
		QuestTreeDetailImageItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestTreeDetailImageItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013929 RID: 80169 RVA: 0x00575B77 File Offset: 0x00573D77
	protected override void OnStart()
	{
		this.RefreshBtnState();
	}

	// Token: 0x0601392A RID: 80170 RVA: 0x00575B7F File Offset: 0x00573D7F
	public void RefreshInfo(QuestTreeNodeData data)
	{
		this.RefreshInfoAsync(data);
	}

	// Token: 0x0601392B RID: 80171 RVA: 0x00575B8C File Offset: 0x00573D8C
	public UniTask RefreshInfoAsync(QuestTreeNodeData data)
	{
		QuestTreeDetailImageItem.<RefreshInfoAsync>d__9 <RefreshInfoAsync>d__;
		<RefreshInfoAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshInfoAsync>d__.<>4__this = this;
		<RefreshInfoAsync>d__.data = data;
		<RefreshInfoAsync>d__.<>1__state = -1;
		<RefreshInfoAsync>d__.<>t__builder.Start<QuestTreeDetailImageItem.<RefreshInfoAsync>d__9>(ref <RefreshInfoAsync>d__);
		return <RefreshInfoAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601392C RID: 80172 RVA: 0x00575BD8 File Offset: 0x00573DD8
	private void RefreshBtnState()
	{
		base.GetItem(2).SetUIActive(this.Data.State == EQuestTreeNodeState.Locked);
		base.GetItem(4).SetUIActive(this.Data.State == EQuestTreeNodeState.InProgress);
		base.GetItem(5).SetUIActive(this.Data.State >= EQuestTreeNodeState.Finished);
	}

	// Token: 0x0601392D RID: 80173 RVA: 0x00575C38 File Offset: 0x00573E38
	private void FixTextureSize()
	{
		UUITexture texture = base.GetTexture(1);
		UTexture2D utexture2D = texture.GetTexture() as UTexture2D;
		if (utexture2D != null)
		{
			float originalWidth = this.OriginalWidth;
			float originalHeight = this.OriginalHeight;
			int num = utexture2D.Blueprint_GetSizeX();
			int num2 = utexture2D.Blueprint_GetSizeY();
			float val = originalWidth / (float)num;
			float val2 = originalHeight / (float)num2;
			float num3 = Math.Max(val, val2);
			texture.SetWidth((float)num * num3);
			texture.SetHeight((float)num2 * num3);
		}
	}

	// Token: 0x0601392E RID: 80174 RVA: 0x00575CA4 File Offset: 0x00573EA4
	private void OnClickImage()
	{
		if (this.Data.State < EQuestTreeNodeState.Finished)
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestTreeNodeImageView, this.Data, null);
	}

	// Token: 0x04009866 RID: 39014
	private float OriginalWidth;

	// Token: 0x04009867 RID: 39015
	private float OriginalHeight;

	// Token: 0x04009868 RID: 39016
	private QuestTreeNodeData Data = data;

	// Token: 0x02008A6B RID: 35435
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x0402EAF6 RID: 191222
		public const int ItemSelf = 0;

		// Token: 0x0402EAF7 RID: 191223
		public const int TextureImage = 1;

		// Token: 0x0402EAF8 RID: 191224
		public const int ItemLock = 2;

		// Token: 0x0402EAF9 RID: 191225
		public const int BtnImage = 3;

		// Token: 0x0402EAFA RID: 191226
		public const int ItemInProgress = 4;

		// Token: 0x0402EAFB RID: 191227
		public const int ItemIcon = 5;
	}
}
