using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015AF RID: 5551
public class SignRewardItemBase : UiPanelBase
{
	// Token: 0x06009C64 RID: 40036 RVA: 0x0028F4AF File Offset: 0x0028D6AF
	public virtual void RefreshByData(OneItemConfig data, SignState state, int index)
	{
	}

	// Token: 0x06009C65 RID: 40037 RVA: 0x0028F4B1 File Offset: 0x0028D6B1
	[NullableContext(1)]
	protected string GetRewardStateTextId(SignState state)
	{
		switch (state)
		{
		case SignState.Lock:
			return "NeedSign";
		case SignState.Unlock:
			return "CanGetReward";
		case SignState.IsReceive:
			return "CollectActivity_state_recived";
		default:
			return "NeedSign";
		}
	}

	// Token: 0x06009C66 RID: 40038 RVA: 0x0028F4DE File Offset: 0x0028D6DE
	protected void OnClickToggle(EToggleState toggleState)
	{
		Action<int> onClickToGet = this.OnClickToGet;
		if (onClickToGet == null)
		{
			return;
		}
		onClickToGet(this.Index);
	}

	// Token: 0x06009C67 RID: 40039 RVA: 0x0028F4F6 File Offset: 0x0028D6F6
	protected void OnClickButton()
	{
		Action<int> onClickToGet = this.OnClickToGet;
		if (onClickToGet == null)
		{
			return;
		}
		onClickToGet(this.Index);
	}

	// Token: 0x06009C68 RID: 40040 RVA: 0x0028F50E File Offset: 0x0028D70E
	protected override void OnBeforeDestroyImplement()
	{
		this.OnClickToGet = null;
	}

	// Token: 0x040047F7 RID: 18423
	protected int Index;

	// Token: 0x040047F8 RID: 18424
	protected bool CanGetReward;

	// Token: 0x040047F9 RID: 18425
	[Nullable(2)]
	public Action<int> OnClickToGet;
}
