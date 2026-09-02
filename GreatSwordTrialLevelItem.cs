using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001E1B RID: 7707
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GreatSwordTrialLevelItem : GridProxyAbstract<TrialSubChallenge>
{
	// Token: 0x0600E37F RID: 58239 RVA: 0x003D3DD4 File Offset: 0x003D1FD4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x0600E380 RID: 58240 RVA: 0x003D3EAC File Offset: 0x003D20AC
	public override void Refresh(TrialSubChallenge data, bool isSelected, int gridIndex)
	{
		this.LevelIndex = gridIndex;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Config.TitleText, Array.Empty<object>());
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(!data.Unlocked);
		}
		UUIItem item2 = base.GetItem(6);
		if (item2 != null)
		{
			item2.SetUIActive(data.Completed);
		}
		this.RefreshStyleByIndex(data, gridIndex);
	}

	// Token: 0x0600E381 RID: 58241 RVA: 0x003D3F1F File Offset: 0x003D211F
	public override object GetKey(TrialSubChallenge data, int gridIndex)
	{
		return gridIndex;
	}

	// Token: 0x0600E382 RID: 58242 RVA: 0x003D3F28 File Offset: 0x003D2128
	protected override UniTask OnBeforeStartAsync()
	{
		GreatSwordTrialLevelItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GreatSwordTrialLevelItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600E383 RID: 58243 RVA: 0x003D3F6B File Offset: 0x003D216B
	protected override void OnStart()
	{
		base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.OnCanExecuteChange));
	}

	// Token: 0x0600E384 RID: 58244 RVA: 0x003D3F8C File Offset: 0x003D218C
	private void RefreshStyleByIndex(TrialSubChallenge data, int levelIndex)
	{
		BlackSwordUIAsset? config = ConfigBlackSwordUIAssetById.GetConfig(data.Config.UIConfigId, true);
		string[] array = ((config != null) ? config.GetValueOrDefault().LevelColors() : null) ?? Array.Empty<string>();
		string[] array2 = ((config != null) ? config.GetValueOrDefault().PatternPaths() : null) ?? Array.Empty<string>();
		string[] array3 = ((config != null) ? config.GetValueOrDefault().StarPaths() : null) ?? Array.Empty<string>();
		string hexStr = (levelIndex < array.Length) ? array[levelIndex] : "#ffffff";
		string path = (levelIndex < array2.Length) ? array2[levelIndex] : "";
		string path2 = (levelIndex < array3.Length) ? array3[levelIndex] : "";
		FColor color = FColor.FromHex(hexStr);
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			texture.SetColor(color);
		}
		UUITexture texture2 = base.GetTexture(3);
		base.SetTextureByPath(path, texture2, null, null);
		UUITexture texture3 = base.GetTexture(4);
		base.SetTextureByPath(path2, texture3, null, null);
		bool flag = !data.Unlocked || data.Completed;
		if (texture3 != null)
		{
			texture3.SetUIActive(!flag);
		}
	}

	// Token: 0x0600E385 RID: 58245 RVA: 0x003D40CF File Offset: 0x003D22CF
	public void SetToggleState(EToggleState state)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x0600E386 RID: 58246 RVA: 0x003D40E7 File Offset: 0x003D22E7
	public EToggleState GetToggleState()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return EToggleState.ETT_UnChecked;
		}
		return extendToggle.GetToggleState();
	}

	// Token: 0x0600E387 RID: 58247 RVA: 0x003D40FB File Offset: 0x003D22FB
	protected void OnClickToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			Action<int> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(this.LevelIndex);
		}
	}

	// Token: 0x0600E388 RID: 58248 RVA: 0x003D4117 File Offset: 0x003D2317
	private bool OnCanExecuteChange()
	{
		return this.CanClickCallBack != null && this.CanClickCallBack(this.LevelIndex);
	}

	// Token: 0x04006D6F RID: 28015
	public int LevelIndex;

	// Token: 0x04006D70 RID: 28016
	[Nullable(2)]
	public Action<int> OnClickToggleCallBack;

	// Token: 0x04006D71 RID: 28017
	[Nullable(2)]
	public Func<int, bool> CanClickCallBack;
}
