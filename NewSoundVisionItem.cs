using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.AdventureGuide.Views;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001760 RID: 5984
public class NewSoundVisionItem : UiPanelBase, INewSoundItem
{
	// Token: 0x0600A82F RID: 43055 RVA: 0x002CC934 File Offset: 0x002CAB34
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A830 RID: 43056 RVA: 0x002CCA21 File Offset: 0x002CAC21
	protected override void OnStart()
	{
		this.PhantomLayout = new GenericLayout<NewSoundNormaPhantomItem, int>(base.GetVerticalLayout(3), new Func<NewSoundNormaPhantomItem>(this.OnPhantomInit), null, false, true);
	}

	// Token: 0x0600A831 RID: 43057 RVA: 0x002CCA44 File Offset: 0x002CAC44
	[NullableContext(1)]
	public void Update(NewSoundDetectItemData sourceData)
	{
		SoundAreaDetectionRecord detectRecordData = sourceData.DetectRecordData;
		UUIText text = base.GetText(0);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, detectRecordData.Name, Array.Empty<object>());
		UUITexture texture = base.GetTexture(1);
		UUIText text2 = base.GetText(2);
		this.RefreshTraceItemState(sourceData);
		if (detectRecordData.Secondary == 63 || detectRecordData.Secondary == 64)
		{
			bool isDetectionPreOpenByRecord = ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByRecord(detectRecordData.SilentAreaDetectionRecord);
			ValueTuple<long, int> valueTuple = new ValueTuple<long, int>(0L, 0);
			if (isDetectionPreOpenByRecord)
			{
				PreOpenDetection? preOpenDetectionConf = ModelBase<AdventureGuideModel>.Instance.GetPreOpenDetectionConf(detectRecordData.Id, detectRecordData.Type.Value, detectRecordData.PreOpenId);
				valueTuple = ModelBase<AdventureGuideModel>.Instance.GetNightMarePreOpenTarget(preOpenDetectionConf.Value.InstanceID);
			}
			else
			{
				ValueTuple<int, int> nightMareTarget = ModelBase<AdventureGuideModel>.Instance.GetNightMareTarget(new int?(detectRecordData.SilentAreaDetectionRecord.Conf.MapId), new int?(detectRecordData.SilentAreaDetectionRecord.Conf.LevelPlayList()[0]));
				valueTuple = new ValueTuple<long, int>((long)nightMareTarget.Item1, nightMareTarget.Item2);
			}
			if (valueTuple.Item2 < 0)
			{
				if (text2 != null)
				{
					text2.SetText("", true);
				}
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, "NightMareLeftTimes", new <>z__ReadOnlyArray<object>(new object[]
				{
					valueTuple.Item1,
					valueTuple.Item2
				}));
			}
			base.SetTextureShowUntilLoaded(detectRecordData.BigIcon, texture, null);
		}
		else
		{
			bool isDetectionPreOpenByData = ModelBase<AdventureGuideModel>.Instance.GetIsDetectionPreOpenByData(detectRecordData);
			if (detectRecordData.IsLock.GetValueOrDefault() && !isDetectionPreOpenByData)
			{
				base.SetTextureShowUntilLoaded(detectRecordData.LockBigIcon, texture, null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, detectRecordData.AttributesDescriptionUnlock, Array.Empty<object>());
				GenericLayout<NewSoundNormaPhantomItem, int> phantomLayout = this.PhantomLayout;
				if (phantomLayout == null)
				{
					return;
				}
				phantomLayout.SetActive(false);
				return;
			}
			else
			{
				base.SetTextureShowUntilLoaded(detectRecordData.BigIcon, texture, null);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, detectRecordData.InstanceSubTypeDescription, Array.Empty<object>());
			}
		}
		if (detectRecordData.Secondary != 22 || detectRecordData.PhantomId == null || detectRecordData.PhantomId.Length == 0)
		{
			GenericLayout<NewSoundNormaPhantomItem, int> phantomLayout2 = this.PhantomLayout;
			if (phantomLayout2 == null)
			{
				return;
			}
			phantomLayout2.SetActive(false);
			return;
		}
		else
		{
			GenericLayout<NewSoundNormaPhantomItem, int> phantomLayout3 = this.PhantomLayout;
			if (phantomLayout3 != null)
			{
				phantomLayout3.SetActive(true);
			}
			GenericLayout<NewSoundNormaPhantomItem, int> phantomLayout4 = this.PhantomLayout;
			if (phantomLayout4 == null)
			{
				return;
			}
			phantomLayout4.RefreshByData(detectRecordData.PhantomId.ToList<int>(), null, false);
			return;
		}
	}

	// Token: 0x0600A832 RID: 43058 RVA: 0x002CCC94 File Offset: 0x002CAE94
	[NullableContext(1)]
	private void RefreshTraceItemState(NewSoundDetectItemData data)
	{
		List<int> tracingList = data.TracingList;
		bool uiactive = tracingList != null && tracingList.Contains(data.DetectRecordData.Id);
		UUIItem item = base.GetItem(5);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(uiactive);
	}

	// Token: 0x0600A833 RID: 43059 RVA: 0x002CCCD1 File Offset: 0x002CAED1
	[NullableContext(1)]
	private NewSoundNormaPhantomItem OnPhantomInit()
	{
		return new NewSoundNormaPhantomItem();
	}

	// Token: 0x04004F4E RID: 20302
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<NewSoundNormaPhantomItem, int> PhantomLayout;

	// Token: 0x02007AC4 RID: 31428
	private enum EChildType
	{
		// Token: 0x0402A0D2 RID: 172242
		NameText,
		// Token: 0x0402A0D3 RID: 172243
		IconTexture,
		// Token: 0x0402A0D4 RID: 172244
		DesText,
		// Token: 0x0402A0D5 RID: 172245
		PhantomLayout,
		// Token: 0x0402A0D6 RID: 172246
		SpriteIcon,
		// Token: 0x0402A0D7 RID: 172247
		TrackIcon
	}
}
