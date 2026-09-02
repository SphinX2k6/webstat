using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022D7 RID: 8919
public class MotorcycleDiySkinObtainItem : UiPanelBase
{
	// Token: 0x06010E02 RID: 69122 RVA: 0x0049F540 File Offset: 0x0049D740
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickObtain))
		};
	}

	// Token: 0x06010E03 RID: 69123 RVA: 0x0049F5EC File Offset: 0x0049D7EC
	[NullableContext(1)]
	public void Refresh(IList<int> accessIdList)
	{
		if (accessIdList.Count <= 0)
		{
			return;
		}
		int num = accessIdList[0];
		AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(num);
		if (accessPathConfig != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), accessPathConfig.Value.Description, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), accessPathConfig.Value.Description, Array.Empty<object>());
			ESkipName skipName = (ESkipName)accessPathConfig.Value.SkipName;
			base.GetItem(1).SetUIActive(skipName != ESkipName.NoSkip);
			base.GetItem(2).SetUIActive(skipName == ESkipName.NoSkip);
		}
		this.JumpId = num;
	}

	// Token: 0x06010E04 RID: 69124 RVA: 0x0049F6A4 File Offset: 0x0049D8A4
	private void OnClickObtain()
	{
		if (this.JumpId <= 0)
		{
			return;
		}
		Action onClickObtainBack = this.OnClickObtainBack;
		if (onClickObtainBack != null)
		{
			onClickObtainBack();
		}
		SkipTaskManager.RunByConfigId(this.JumpId, null);
	}

	// Token: 0x040084F5 RID: 34037
	private int JumpId;

	// Token: 0x040084F6 RID: 34038
	[Nullable(2)]
	public Action OnClickObtainBack;

	// Token: 0x020085B3 RID: 34227
	private class EMotorDiySkinObtainItemComponent
	{
		// Token: 0x0402D3BA RID: 185274
		public const int BtnObtain = 0;

		// Token: 0x0402D3BB RID: 185275
		public const int HasAccessItem = 1;

		// Token: 0x0402D3BC RID: 185276
		public const int LockItem = 2;

		// Token: 0x0402D3BD RID: 185277
		public const int TxtAccess = 3;

		// Token: 0x0402D3BE RID: 185278
		public const int TxtLock = 4;
	}
}
