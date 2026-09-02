using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02002FAA RID: 12202
public class GameplayCueHitEffect : GameplayCueBase
{
	// Token: 0x06018E1F RID: 101919 RVA: 0x0070C51C File Offset: 0x0070A71C
	protected override void OnCreate()
	{
		if (string.IsNullOrEmpty(this.CueConfig.Path))
		{
			return;
		}
		this.HandleId = Singleton<ResourceSystem>.Instance.LoadAsync<BP_ReplaceHitEffect_C>(this.CueConfig.Path, delegate([Nullable(2)] BP_ReplaceHitEffect_C res, string _)
		{
			this.HandleId = 0;
			if (this.ReplaceHitEffect(res))
			{
				this.IsReplaced = true;
			}
		}, 100, "js_undefined");
	}

	// Token: 0x06018E20 RID: 101920 RVA: 0x0070C56A File Offset: 0x0070A76A
	protected override void OnDestroy()
	{
		if (this.HandleId != 0)
		{
			Singleton<ResourceSystem>.Instance.CancelAsyncLoad(this.HandleId);
			this.HandleId = 0;
		}
		if (this.IsReplaced)
		{
			this.IsReplaced = false;
			this.RemoveHitEffectReplaced();
		}
	}

	// Token: 0x06018E21 RID: 101921 RVA: 0x0070C5A0 File Offset: 0x0070A7A0
	[NullableContext(2)]
	private bool ReplaceHitEffect(BP_ReplaceHitEffect_C dataAsset)
	{
		if (dataAsset == null)
		{
			return false;
		}
		if (!this.EntityHandle.Valid)
		{
			return false;
		}
		CharacterHitComponent component = this.EntityHandle.Entity.GetComponent<CharacterHitComponent>();
		return component != null && component.ReplaceHitEffect(dataAsset);
	}

	// Token: 0x06018E22 RID: 101922 RVA: 0x0070C5E0 File Offset: 0x0070A7E0
	private void RemoveHitEffectReplaced()
	{
		if (!this.EntityHandle.Valid)
		{
			return;
		}
		CharacterHitComponent component = this.EntityHandle.Entity.GetComponent<CharacterHitComponent>();
		if (component == null)
		{
			return;
		}
		component.RemoveHitEffectReplaced();
	}

	// Token: 0x0400C269 RID: 49769
	private int HandleId;

	// Token: 0x0400C26A RID: 49770
	private bool IsReplaced;
}
