using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x020030FE RID: 12542
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class PerformController : ControllerBase<PerformController>
{
	// Token: 0x06019EFB RID: 106235 RVA: 0x007959ED File Offset: 0x00793BED
	protected override bool OnInit()
	{
		Singleton<Net>.Instance.Register<CharacterLookAtNotify>(ENotifyMessageId.CharacterLookAtNotify, new Action<CharacterLookAtNotify, Net.CallbackStatus>(this.OnCharacterLookAtNotify));
		return true;
	}

	// Token: 0x06019EFC RID: 106236 RVA: 0x00795A0C File Offset: 0x00793C0C
	protected override bool OnClear()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CharacterLookAtNotify);
		return true;
	}

	// Token: 0x06019EFD RID: 106237 RVA: 0x00795A20 File Offset: 0x00793C20
	private void OnCharacterLookAtNotify(CharacterLookAtNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		foreach (CharacterLookAtInfo sightTarget in data.CharacterLookAtInfos)
		{
			ModelBase<PerformModel>.Instance.SetSightTarget(sightTarget);
		}
	}

	// Token: 0x06019EFE RID: 106238 RVA: 0x00795A74 File Offset: 0x00793C74
	public void RecoverTreeInfo(IList<CharacterLookAtInfo> data)
	{
		foreach (CharacterLookAtInfo sightTarget in data)
		{
			ModelBase<PerformModel>.Instance.SetSightTarget(sightTarget);
		}
	}

	// Token: 0x06019EFF RID: 106239 RVA: 0x00795AC0 File Offset: 0x00793CC0
	protected override bool OnLeaveLevel()
	{
		PerformActionPool.Clear();
		return true;
	}
}
