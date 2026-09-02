using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020025D2 RID: 9682
[NullableContext(1)]
[Nullable(0)]
public class PhotographDropDownSetup : PhotographSetupBase
{
	// Token: 0x06012ED9 RID: 77529 RVA: 0x0053C90C File Offset: 0x0053AB0C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06012EDA RID: 77530 RVA: 0x0053C998 File Offset: 0x0053AB98
	protected override UniTask OnBeforeStartAsync()
	{
		PhotographDropDownSetup.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhotographDropDownSetup.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012EDB RID: 77531 RVA: 0x0053C9DB File Offset: 0x0053ABDB
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06012EDC RID: 77532 RVA: 0x0053C9F0 File Offset: 0x0053ABF0
	protected override void OnBeforeShow()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer == null)
		{
			return;
		}
		levelSequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
	}

	// Token: 0x06012EDD RID: 77533 RVA: 0x0053CA1D File Offset: 0x0053AC1D
	public override void Initialize(EPhotoSetupValueType setupValueType)
	{
		this.SetupValueType = setupValueType;
		this.Refresh();
		this.RefreshRedDot();
	}

	// Token: 0x06012EDE RID: 77534 RVA: 0x0053CA34 File Offset: 0x0053AC34
	private void RefreshRedDot()
	{
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(base.IsPhotoSetupRedDotVisible());
	}

	// Token: 0x06012EDF RID: 77535 RVA: 0x0053CA5C File Offset: 0x0053AC5C
	public override void Refresh()
	{
		this.SetupConfig = ConfigBase<PhotographConfig>.Instance.GetPhotoSetupConfig(this.SetupValueType);
		if (this.SetupConfig.Value.Type != 2)
		{
			return;
		}
		string name = this.SetupConfig.Value.Name;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, name, Array.Empty<object>());
		this.RefreshDropDown();
	}

	// Token: 0x06012EE0 RID: 77536 RVA: 0x0053CACC File Offset: 0x0053ACCC
	private void RefreshDropDown()
	{
		IReadOnlyList<PhotoDropDown> photoDropDownDataList = ConfigBase<PhotographConfig>.Instance.GetPhotoDropDownDataList(this.SetupValueType);
		List<PhotoDropDown> list = new List<PhotoDropDown>();
		for (int i = 0; i < photoDropDownDataList.Count; i++)
		{
			PhotoDropDown item = photoDropDownDataList[i];
			if (item.IsShowInLowDevice || !Singleton<Info>.Instance.IsLowMemoryDevice)
			{
				list.Add(item);
			}
		}
		float? photographOption = ModelBase<PhotographModel>.Instance.GetPhotographOption(this.SetupValueType);
		int defaultIndex = -1;
		for (int j = 0; j < list.Count; j++)
		{
			float num = (float)list[j].Id;
			float? num2 = photographOption;
			if (num == num2.GetValueOrDefault() & num2 != null)
			{
				defaultIndex = j;
			}
		}
		this.DropDown.InitScroll(list, new Func<PhotoDropDown, TableTextArgNew>(this.GetDropDownTextId), defaultIndex, true);
	}

	// Token: 0x06012EE1 RID: 77537 RVA: 0x0053CB99 File Offset: 0x0053AD99
	private TableTextArgNew GetDropDownTextId(PhotoDropDown data)
	{
		return new TableTextArgNew(data.TextId, Array.Empty<object>());
	}

	// Token: 0x06012EE2 RID: 77538 RVA: 0x0053CBAC File Offset: 0x0053ADAC
	protected override void OnBeforeDestroy()
	{
		this.LevelSequencePlayer = null;
	}

	// Token: 0x06012EE3 RID: 77539 RVA: 0x0053CBB5 File Offset: 0x0053ADB5
	private void OnDropDownOpen()
	{
		base.MarkPhotoSetupRedDotAsRead(delegate
		{
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		});
	}

	// Token: 0x06012EE4 RID: 77540 RVA: 0x0053CBCC File Offset: 0x0053ADCC
	private void OnSelectChange(int index, PhotoDropDown data)
	{
		if (this.SetupValueType == EPhotoSetupValueType.ImageQuality)
		{
			ControllerBase<PhotographController>.Instance.SetPhotographOption((EPhotoSetupValueType)this.SetupConfig.Value.ValueType, (float)data.Id, false);
		}
		if (this.SetupConfig.Value.IsLocalStorage)
		{
			Dictionary<int, int> dictionary = LocalStorage.GetGlobal<Dictionary<int, int>>(ELocalStorageGlobalKey.PhotographSetupOption, null) ?? new Dictionary<int, int>();
			dictionary[(int)this.SetupValueType] = data.Id;
			LocalStorage.SetGlobal<Dictionary<int, int>>(ELocalStorageGlobalKey.PhotographSetupOption, dictionary);
		}
	}

	// Token: 0x06012EE5 RID: 77541 RVA: 0x0053CC51 File Offset: 0x0053AE51
	private OneTextDropDownItem CreateDropDownItem(UUIItem uiItem, PhotoDropDown data)
	{
		return new OneTextDropDownItem(uiItem);
	}

	// Token: 0x06012EE6 RID: 77542 RVA: 0x0053CC59 File Offset: 0x0053AE59
	private OneTextTitleItem CreateTitleItem(UUIItem uiItem)
	{
		return new OneTextTitleItem(uiItem);
	}

	// Token: 0x040093D0 RID: 37840
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040093D1 RID: 37841
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private CommonDropDown<TableTextArgNew, PhotoDropDown> DropDown;

	// Token: 0x0200893F RID: 35135
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402E4F3 RID: 189683
		public const int OptionNameText = 0;

		// Token: 0x0402E4F4 RID: 189684
		public const int ItemDropDown = 1;

		// Token: 0x0402E4F5 RID: 189685
		public const int ItemRedDot = 2;
	}
}
