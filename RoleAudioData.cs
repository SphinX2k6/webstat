using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;

// Token: 0x020027B9 RID: 10169
[NullableContext(1)]
[Nullable(0)]
public class RoleAudioData : RoleModuleDataBase
{
	// Token: 0x060141B2 RID: 82354 RVA: 0x0059DCCE File Offset: 0x0059BECE
	public RoleAudioData(int roleId) : base(roleId)
	{
		this.InitAudioData();
	}

	// Token: 0x060141B3 RID: 82355 RVA: 0x0059DCE8 File Offset: 0x0059BEE8
	private void InitAudioData()
	{
		IReadOnlyList<RoleAnimAudio> roleAudioMap = ConfigBase<RoleConfig>.Instance.GetRoleAudioMap(this.RoleId);
		if (roleAudioMap == null)
		{
			return;
		}
		foreach (RoleAnimAudio roleAnimAudio in roleAudioMap)
		{
			RoleAnimAudioData value = new RoleAnimAudioData(roleAnimAudio.CanInterrupt, roleAnimAudio.AudioPath);
			this.AudioMap[roleAnimAudio.ActionName] = value;
		}
	}

	// Token: 0x060141B4 RID: 82356 RVA: 0x0059DD68 File Offset: 0x0059BF68
	[return: Nullable(2)]
	public RoleAnimAudioData GetAudioPathByName(string animName)
	{
		if (this.AudioMap == null)
		{
			return null;
		}
		RoleAnimAudioData result;
		if (!this.AudioMap.TryGetValue(animName, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x04009C6D RID: 40045
	private readonly Dictionary<string, RoleAnimAudioData> AudioMap = new Dictionary<string, RoleAnimAudioData>();
}
