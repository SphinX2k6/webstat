using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001491 RID: 5265
public class ActivitySubViewPhantomCollectMonsterItem : UiPanelBase
{
	// Token: 0x06009363 RID: 37731 RVA: 0x0026E2C8 File Offset: 0x0026C4C8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnSelf));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009364 RID: 37732 RVA: 0x0026E38F File Offset: 0x0026C58F
	private void OnClickBtnSelf()
	{
		if (this.MonsterId != 0)
		{
			ControllerBase<CalabashController>.Instance.JumpToCalabashCollectTabView(this.MonsterId);
		}
	}

	// Token: 0x06009365 RID: 37733 RVA: 0x0026E3AC File Offset: 0x0026C5AC
	public void Refresh(int monsterId)
	{
		this.MonsterId = monsterId;
		ActivityPhantomCollectConfig instance = ConfigBase<ActivityPhantomCollectConfig>.Instance;
		string text;
		((instance != null) ? instance.GetPhantomCollectConfig(ControllerBase<ActivityPhantomCollectController>.Instance.ActivityId) : null).Value.PhantomActivityImage().TryGetValue(monsterId, out text);
		bool phantomIsUnlock = ModelBase<PhantomBattleModel>.Instance.GetPhantomIsUnlock(monsterId);
		if (!string.IsNullOrEmpty(text) && phantomIsUnlock)
		{
			base.SetTextureByPath(text, base.GetTexture(1), null, null);
		}
		base.GetItem(2).SetUIActive(phantomIsUnlock && !ModelBase<CalabashModel>.Instance.CheckMonsterIdInRecord(monsterId));
	}

	// Token: 0x04004429 RID: 17449
	public int MonsterId;

	// Token: 0x0200789E RID: 30878
	private class EActivitySubViewPhantomCollectMonsterItem
	{
		// Token: 0x0402978A RID: 169866
		public const int BtnSelf = 0;

		// Token: 0x0402978B RID: 169867
		public const int TextureMonster = 1;

		// Token: 0x0402978C RID: 169868
		public const int RedDotItem = 2;
	}
}
