using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Module.Skin;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200256F RID: 9583
[NullableContext(2)]
[Nullable(0)]
public class SettingPanelChatRightItem : UiPanelBase
{
	// Token: 0x06012A4E RID: 76366 RVA: 0x00524090 File Offset: 0x00522290
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUITexture)),
			new ValueTuple<int, Type>(10, typeof(UUISprite)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(21, typeof(UUIItem))
		};
	}

	// Token: 0x06012A4F RID: 76367 RVA: 0x005241CA File Offset: 0x005223CA
	public void InitView()
	{
		this.RefreshSpeakerInfo();
	}

	// Token: 0x06012A50 RID: 76368 RVA: 0x005241D4 File Offset: 0x005223D4
	private void RefreshSpeakerInfo()
	{
		int value = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId().Value;
		int roleSkinIdByRoleId = ModelBase<RoleSkinModel>.Instance.GetRoleSkinIdByRoleId(value);
		string roleHeadIconCircle = ConfigBase<SkinConfig>.Instance.GetRoleSkinConfig(roleSkinIdByRoleId).Value.RoleHeadIconCircle;
		string newText = ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "";
		base.GetText(2).SetText(newText, true);
		base.GetText(11).SetText(newText, true);
		this.RefreshSpeakerNameTextColor(ModelBase<PhoneMsgModel>.Instance.CurrentUsingChatBgId);
		base.SetTextureShowUntilLoaded(roleHeadIconCircle, base.GetTexture(1), null);
	}

	// Token: 0x06012A51 RID: 76369 RVA: 0x00524274 File Offset: 0x00522474
	public void OnNameChange()
	{
		string text = ModelBase<FunctionModel>.Instance.GetPlayerName() ?? "";
		if (!string.IsNullOrEmpty(text))
		{
			base.GetText(2).SetText(text, true);
			UUIText text2 = base.GetText(11);
			if (text2 != null)
			{
				text2.SetText(text, true);
			}
		}
	}

	// Token: 0x06012A52 RID: 76370 RVA: 0x005242C0 File Offset: 0x005224C0
	public void RefreshDialog(int dialogId)
	{
		ChatDialog? chatDialogConfig = ConfigBase<PhoneMsgConfig>.Instance.GetChatDialogConfig(dialogId);
		if (chatDialogConfig == null)
		{
			return;
		}
		this.SetSpriteByPath(chatDialogConfig.Value.BgPath, base.GetSprite(10), false, null, null);
		this.TryLoadDynamicDialogNode(chatDialogConfig.Value.SpineItemPath);
		base.GetText(4).SetColor(FColor.FromHex(chatDialogConfig.Value.TextColor));
	}

	// Token: 0x06012A53 RID: 76371 RVA: 0x00524340 File Offset: 0x00522540
	private void TryLoadDynamicDialogNode(string path)
	{
		SettingPanelChatRightItem.<>c__DisplayClass7_0 CS$<>8__locals1 = new SettingPanelChatRightItem.<>c__DisplayClass7_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.path = path;
		UiAsyncTask task = new UiAsyncTask("SettingPanelChatRightItem.TryLoadDynamicDialogNode", delegate()
		{
			SettingPanelChatRightItem.<>c__DisplayClass7_0.<<TryLoadDynamicDialogNode>b__0>d <<TryLoadDynamicDialogNode>b__0>d;
			<<TryLoadDynamicDialogNode>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<TryLoadDynamicDialogNode>b__0>d.<>4__this = CS$<>8__locals1;
			<<TryLoadDynamicDialogNode>b__0>d.<>1__state = -1;
			<<TryLoadDynamicDialogNode>b__0>d.<>t__builder.Start<SettingPanelChatRightItem.<>c__DisplayClass7_0.<<TryLoadDynamicDialogNode>b__0>d>(ref <<TryLoadDynamicDialogNode>b__0>d);
			return <<TryLoadDynamicDialogNode>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task).Forget();
	}

	// Token: 0x06012A54 RID: 76372 RVA: 0x00524388 File Offset: 0x00522588
	private UniTask TryLoadDynamicDialogNodeAsync(string path)
	{
		SettingPanelChatRightItem.<TryLoadDynamicDialogNodeAsync>d__8 <TryLoadDynamicDialogNodeAsync>d__;
		<TryLoadDynamicDialogNodeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<TryLoadDynamicDialogNodeAsync>d__.<>4__this = this;
		<TryLoadDynamicDialogNodeAsync>d__.path = path;
		<TryLoadDynamicDialogNodeAsync>d__.<>1__state = -1;
		<TryLoadDynamicDialogNodeAsync>d__.<>t__builder.Start<SettingPanelChatRightItem.<TryLoadDynamicDialogNodeAsync>d__8>(ref <TryLoadDynamicDialogNodeAsync>d__);
		return <TryLoadDynamicDialogNodeAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012A55 RID: 76373 RVA: 0x005243D4 File Offset: 0x005225D4
	public void RefreshSpeakerNameTextColor(int bgId)
	{
		bool flag = ModelBase<PhoneMsgModel>.Instance.IsDefaultChatBg(bgId);
		base.GetText(2).SetUIActive(flag);
		UUIText text = base.GetText(11);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(!flag);
	}

	// Token: 0x06012A56 RID: 76374 RVA: 0x00524410 File Offset: 0x00522610
	public void HideRedDot()
	{
		base.GetItem(6).SetUIActive(false);
	}

	// Token: 0x040091A5 RID: 37285
	private AActor DynamicDialogActor;

	// Token: 0x040091A6 RID: 37286
	private LevelSequencePlayer DialogSequencePlayer;
}
