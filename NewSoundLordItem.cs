using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.AdventureGuide.Views;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001751 RID: 5969
public class NewSoundLordItem : UiPanelBase, INewSoundItem
{
	// Token: 0x0600A7E0 RID: 42976 RVA: 0x002CAEF8 File Offset: 0x002C90F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A7E1 RID: 42977 RVA: 0x002CAFA3 File Offset: 0x002C91A3
	protected override void OnStart()
	{
		UUIText text = base.GetText(3);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x0600A7E2 RID: 42978 RVA: 0x002CAFB8 File Offset: 0x002C91B8
	[NullableContext(1)]
	public void Update(NewSoundDetectItemData sourceData)
	{
		SoundAreaDetectionRecord detectRecordData = sourceData.DetectRecordData;
		ESoundAreaDataType? type = detectRecordData.Type;
		ESoundAreaDataType esoundAreaDataType = ESoundAreaDataType.Dungeon;
		if (type.GetValueOrDefault() == esoundAreaDataType & type != null)
		{
			return;
		}
		SilentAreaDetection silentAreaDetection = (T2)detectRecordData.Conf.Value;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, silentAreaDetection.Name, Array.Empty<object>());
		UUITexture texture = base.GetTexture(1);
		int gymEntranceId = silentAreaDetection.AdditionalId;
		if (detectRecordData.IsLock.GetValueOrDefault())
		{
			base.SetTextureShowUntilLoaded(silentAreaDetection.LockBigIcon, texture, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "LordGymDifficulty", new <>z__ReadOnlySingleElementList<object>("0/" + ModelBase<LordGymModel>.Instance.GetGymCanFightMaxLevel(gymEntranceId).ToString()));
			return;
		}
		base.SetTextureShowUntilLoaded(silentAreaDetection.BigIcon, texture, null);
		ControllerBase<LordGymController>.Instance.LordGymInfoRequest(0).ContinueWith(delegate(bool _)
		{
			int? gymCanFightMaxLevelWithoutLockCondition = ModelBase<LordGymModel>.Instance.GetGymCanFightMaxLevelWithoutLockCondition(gymEntranceId);
			int hasFinishLord = ModelBase<LordGymModel>.Instance.GetHasFinishLord(gymEntranceId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.GetText(2), "NewSoundLordGymDifficulty", new <>z__ReadOnlyArray<object>(new object[]
			{
				hasFinishLord,
				gymCanFightMaxLevelWithoutLockCondition
			}));
		});
	}

	// Token: 0x02007AB5 RID: 31413
	private enum EChildType
	{
		// Token: 0x0402A090 RID: 172176
		NameText,
		// Token: 0x0402A091 RID: 172177
		IconTexture,
		// Token: 0x0402A092 RID: 172178
		ProgressText,
		// Token: 0x0402A093 RID: 172179
		ProgressNumberText
	}
}
