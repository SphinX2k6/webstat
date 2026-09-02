using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001DB8 RID: 7608
[NullableContext(1)]
[Nullable(0)]
public class PingView : UiViewBase
{
	// Token: 0x0600E082 RID: 57474 RVA: 0x003C5A73 File Offset: 0x003C3C73
	public PingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E083 RID: 57475 RVA: 0x003C5A94 File Offset: 0x003C3C94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E084 RID: 57476 RVA: 0x003C5B20 File Offset: 0x003C3D20
	protected override void OnStart()
	{
		base.GetItem(1).SetUIActive(false);
		this.LastTimeReconnectState = false;
		this.PingUnChangeValue = ConfigBase<CommonConfig>.Instance.GetPingUnChangeValue().Value;
	}

	// Token: 0x0600E085 RID: 57477 RVA: 0x003C5B59 File Offset: 0x003C3D59
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnCheckGamePing, new Action<int>(this.OnRefreshPing));
	}

	// Token: 0x0600E086 RID: 57478 RVA: 0x003C5B77 File Offset: 0x003C3D77
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCheckGamePing, new Action<int>(this.OnRefreshPing));
	}

	// Token: 0x0600E087 RID: 57479 RVA: 0x003C5B98 File Offset: 0x003C3D98
	private void OnRefreshPing(int pingTime)
	{
		if (Math.Abs(pingTime - this.LastTimeShowPing) < this.PingUnChangeValue)
		{
			return;
		}
		this.LastTimeShowPing = pingTime;
		bool flag = pingTime > 500;
		if (flag != this.LastTimeReconnectState)
		{
			base.GetSprite(0).SetUIActive(!flag);
			base.GetItem(1).SetUIActive(flag);
			this.RefreshReconnectAnimation(flag);
			this.LastTimeReconnectState = flag;
		}
		ValueTuple<string, string> spriteAndColorByPing = this.GetSpriteAndColorByPing(pingTime);
		if (this.LastSpritePath != spriteAndColorByPing.Item1)
		{
			this.SetSpriteByPath(spriteAndColorByPing.Item1, base.GetSprite(0), false, null, null);
			this.LastSpritePath = spriteAndColorByPing.Item1;
			base.GetText(2).SetColor(FColor.FromHex(spriteAndColorByPing.Item2));
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), "PingStr", new <>z__ReadOnlySingleElementList<object>(pingTime.ToString()));
	}

	// Token: 0x0600E088 RID: 57480 RVA: 0x003C5C7D File Offset: 0x003C3E7D
	protected override void OnAfterShow()
	{
		this.OnRefreshPing(ModelBase<GamePingModel>.Instance.CurrentPing);
	}

	// Token: 0x0600E089 RID: 57481 RVA: 0x003C5C8F File Offset: 0x003C3E8F
	private void RefreshReconnectAnimation(bool reconnectState)
	{
		if (reconnectState)
		{
			this.UiViewSequence.PlaySequencePurely("Loop", false, false);
			return;
		}
		this.UiViewSequence.StopSequenceByKey("Loop", false, false);
	}

	// Token: 0x0600E08A RID: 57482 RVA: 0x003C5CBC File Offset: 0x003C3EBC
	[return: Nullable(new byte[]
	{
		0,
		2,
		1
	})]
	private ValueTuple<string, string> GetSpriteAndColorByPing(int pingTime)
	{
		if (pingTime <= 100)
		{
			return new ValueTuple<string, string>(this.GetGoodPingSprite(), "30D82DFF");
		}
		if (pingTime > 100 && pingTime <= 200)
		{
			return new ValueTuple<string, string>(this.GetMiddlePingSprite(), "FFD12FFF");
		}
		return new ValueTuple<string, string>(this.GetBadPingSprite(), "FF1F1EFF");
	}

	// Token: 0x0600E08B RID: 57483 RVA: 0x003C5D0D File Offset: 0x003C3F0D
	[NullableContext(2)]
	private string GetGoodPingSprite()
	{
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			return ConfigBase<CommonConfig>.Instance.GetNetGoodSprite();
		}
		if (UKuroLauncherLibrary.GetNetworkConnectionType() == 4)
		{
			return ConfigBase<CommonConfig>.Instance.GetNetGoodSpriteMobile();
		}
		return ConfigBase<CommonConfig>.Instance.GetNetGoodSprite();
	}

	// Token: 0x0600E08C RID: 57484 RVA: 0x003C5D43 File Offset: 0x003C3F43
	[NullableContext(2)]
	private string GetMiddlePingSprite()
	{
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			return ConfigBase<CommonConfig>.Instance.GetNetMiddleSprite();
		}
		if (UKuroLauncherLibrary.GetNetworkConnectionType() == 4)
		{
			return ConfigBase<CommonConfig>.Instance.GetNetMiddleSpriteMobile();
		}
		return ConfigBase<CommonConfig>.Instance.GetNetMiddleSprite();
	}

	// Token: 0x0600E08D RID: 57485 RVA: 0x003C5D79 File Offset: 0x003C3F79
	[NullableContext(2)]
	private string GetBadPingSprite()
	{
		if (Singleton<Info>.Instance.IsPcOrGamepadPlatform())
		{
			return ConfigBase<CommonConfig>.Instance.GetNetBadSprite();
		}
		if (UKuroLauncherLibrary.GetNetworkConnectionType() == 4)
		{
			return ConfigBase<CommonConfig>.Instance.GetNetBadSpriteMobile();
		}
		return ConfigBase<CommonConfig>.Instance.GetNetBadSprite();
	}

	// Token: 0x04006BB9 RID: 27577
	private const int GOODPING = 100;

	// Token: 0x04006BBA RID: 27578
	private const int MIDDLEPING = 200;

	// Token: 0x04006BBB RID: 27579
	private const int LOOPPING = 500;

	// Token: 0x04006BBC RID: 27580
	private const string BADCOLOR = "FF1F1EFF";

	// Token: 0x04006BBD RID: 27581
	private const string MIDDLECOLOR = "FFD12FFF";

	// Token: 0x04006BBE RID: 27582
	private const string GOODCOLOR = "30D82DFF";

	// Token: 0x04006BBF RID: 27583
	private string LastSpritePath = string.Empty;

	// Token: 0x04006BC0 RID: 27584
	private bool LastTimeReconnectState;

	// Token: 0x04006BC1 RID: 27585
	private int LastTimeShowPing = -9999;

	// Token: 0x04006BC2 RID: 27586
	private int PingUnChangeValue;

	// Token: 0x0200815C RID: 33116
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402BF46 RID: 180038
		NetStateSprite,
		// Token: 0x0402BF47 RID: 180039
		ReconnectItem,
		// Token: 0x0402BF48 RID: 180040
		PingText
	}
}
