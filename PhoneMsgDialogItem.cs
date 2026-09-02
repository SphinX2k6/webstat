using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002572 RID: 9586
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class PhoneMsgDialogItem : SyncGridProxyAbstract<PhoneMsgDialogItemData>
{
	// Token: 0x06012A5C RID: 76380 RVA: 0x005245DC File Offset: 0x005227DC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06012A5D RID: 76381 RVA: 0x005246B1 File Offset: 0x005228B1
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PhoneMsgDialogAndBgUpdate, new Action(this.OnRedDotUpdate));
	}

	// Token: 0x06012A5E RID: 76382 RVA: 0x005246CF File Offset: 0x005228CF
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PhoneMsgDialogAndBgUpdate, new Action(this.OnRedDotUpdate));
	}

	// Token: 0x06012A5F RID: 76383 RVA: 0x005246ED File Offset: 0x005228ED
	private void OnRedDotUpdate()
	{
		this.RefreshRedDot();
	}

	// Token: 0x06012A60 RID: 76384 RVA: 0x005246F5 File Offset: 0x005228F5
	public void RefreshRedDot()
	{
		UUIItem item = base.GetItem(6);
		PhoneMsgDialogItemData phoneMsgDialogData = this.PhoneMsgDialogData;
		item.SetUIActive(phoneMsgDialogData != null && phoneMsgDialogData.IsHasRedDot());
	}

	// Token: 0x06012A61 RID: 76385 RVA: 0x00524715 File Offset: 0x00522915
	public void HideRedDot()
	{
		base.GetItem(6).SetUIActive(false);
	}

	// Token: 0x06012A62 RID: 76386 RVA: 0x00524724 File Offset: 0x00522924
	[NullableContext(1)]
	public override void Refresh(PhoneMsgDialogItemData data)
	{
		if (data == null)
		{
			return;
		}
		this.PhoneMsgDialogData = data;
		ChatDialog? chatDialogConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatDialogConfig(data.DialogId);
		if (chatDialogConfig != null)
		{
			this.SetSpriteByPath(chatDialogConfig.Value.BgPath, base.GetSprite(1), false, null, null);
		}
		this.TryLoadDynamicDialogNode(chatDialogConfig.Value.SpineItemPath);
		base.GetText(4).SetColor(FColor.FromHex(chatDialogConfig.Value.TextColor));
		base.GetSprite(2).SetUIActive(data.IsUsing);
		base.GetItem(3).SetUIActive(!data.IsUnlocked);
		base.GetItem(6).SetUIActive(data.IsHasRedDot());
		this.SetToggleState(data.IsSelected, true);
	}

	// Token: 0x06012A63 RID: 76387 RVA: 0x005247F8 File Offset: 0x005229F8
	private void TryLoadDynamicDialogNode(string path)
	{
		PhoneMsgDialogItem.<>c__DisplayClass11_0 CS$<>8__locals1 = new PhoneMsgDialogItem.<>c__DisplayClass11_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.path = path;
		UiAsyncTask task = new UiAsyncTask("PhoneMsgDialogItem.TryLoadDynamicDialogNode", delegate()
		{
			PhoneMsgDialogItem.<>c__DisplayClass11_0.<<TryLoadDynamicDialogNode>b__0>d <<TryLoadDynamicDialogNode>b__0>d;
			<<TryLoadDynamicDialogNode>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<TryLoadDynamicDialogNode>b__0>d.<>4__this = CS$<>8__locals1;
			<<TryLoadDynamicDialogNode>b__0>d.<>1__state = -1;
			<<TryLoadDynamicDialogNode>b__0>d.<>t__builder.Start<PhoneMsgDialogItem.<>c__DisplayClass11_0.<<TryLoadDynamicDialogNode>b__0>d>(ref <<TryLoadDynamicDialogNode>b__0>d);
			return <<TryLoadDynamicDialogNode>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task).Forget();
	}

	// Token: 0x06012A64 RID: 76388 RVA: 0x00524840 File Offset: 0x00522A40
	private UniTask TryLoadDynamicDialogNodeAsync(string path)
	{
		PhoneMsgDialogItem.<TryLoadDynamicDialogNodeAsync>d__12 <TryLoadDynamicDialogNodeAsync>d__;
		<TryLoadDynamicDialogNodeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryLoadDynamicDialogNodeAsync>d__.<>4__this = this;
		<TryLoadDynamicDialogNodeAsync>d__.path = path;
		<TryLoadDynamicDialogNodeAsync>d__.<>1__state = -1;
		<TryLoadDynamicDialogNodeAsync>d__.<>t__builder.Start<PhoneMsgDialogItem.<TryLoadDynamicDialogNodeAsync>d__12>(ref <TryLoadDynamicDialogNodeAsync>d__);
		return <TryLoadDynamicDialogNodeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012A65 RID: 76389 RVA: 0x0052488B File Offset: 0x00522A8B
	private void DestroyDynamicDialogActor()
	{
		if (this.DynamicDialogActor != null && this.DynamicDialogActor.IsValid())
		{
			ULGUIBPLibrary.DestroyActorWithHierarchy(this.DynamicDialogActor, true);
			this.DynamicDialogActor = null;
		}
	}

	// Token: 0x06012A66 RID: 76390 RVA: 0x005248B8 File Offset: 0x00522AB8
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.OnToggleCallBack != null && this.PhoneMsgDialogData != null)
		{
			this.OnToggleCallBack(base.GridIndex, this.PhoneMsgDialogData);
		}
		PhoneMsgDialogItemData phoneMsgDialogData = this.PhoneMsgDialogData;
		if (phoneMsgDialogData != null && phoneMsgDialogData.IsHasRedDot())
		{
			ModelBase<PhoneMsgModel>.Instance.RemoveChatShowRedDotById(this.PhoneMsgDialogData.DialogId);
			base.GetItem(6).SetUIActive(false);
		}
	}

	// Token: 0x06012A67 RID: 76391 RVA: 0x00524924 File Offset: 0x00522B24
	public void SetToggleState(bool state, bool isFirstRefresh = false)
	{
		if (this.PhoneMsgDialogData == null)
		{
			return;
		}
		this.PhoneMsgDialogData.IsSelected = state;
		EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state2, false, isFirstRefresh, isFirstRefresh);
	}

	// Token: 0x040091AF RID: 37295
	private PhoneMsgDialogItemData PhoneMsgDialogData;

	// Token: 0x040091B0 RID: 37296
	private AActor DynamicDialogActor;

	// Token: 0x040091B1 RID: 37297
	private LevelSequencePlayer DialogSequencePlayer;

	// Token: 0x040091B2 RID: 37298
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<int, PhoneMsgDialogItemData> OnToggleCallBack;
}
