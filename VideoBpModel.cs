using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Sequence.Seq_BP.BPSeqDissolve;
using CSharpScript.Game;
using UnrealEngine;

// Token: 0x02002CDE RID: 11486
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class VideoBpModel : ModelBase<VideoBpModel>
{
	// Token: 0x17001E77 RID: 7799
	// (get) Token: 0x06017262 RID: 94818 RVA: 0x0066A085 File Offset: 0x00668285
	public BP_MediaDissolveManagea_C VideoBp
	{
		get
		{
			return this.VideoBpInternal;
		}
	}

	// Token: 0x06017263 RID: 94819 RVA: 0x0066A08D File Offset: 0x0066828D
	[NullableContext(1)]
	public void AddToPreloadMap(string name, UMediaSource source)
	{
		this.VideoPreloadMap[name] = source;
	}

	// Token: 0x06017264 RID: 94820 RVA: 0x0066A09C File Offset: 0x0066829C
	[NullableContext(1)]
	[return: Nullable(2)]
	public UMediaSource GetFromPreloadMap(string name)
	{
		UMediaSource result;
		if (this.VideoPreloadMap.TryGetValue(name, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06017265 RID: 94821 RVA: 0x0066A0BC File Offset: 0x006682BC
	public void ClearPreloadMap()
	{
		this.VideoPreloadMap.Clear();
	}

	// Token: 0x06017266 RID: 94822 RVA: 0x0066A0C9 File Offset: 0x006682C9
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06017267 RID: 94823 RVA: 0x0066A0CC File Offset: 0x006682CC
	protected override bool OnClear()
	{
		this.RemoveOnVideoEnd();
		return true;
	}

	// Token: 0x06017268 RID: 94824 RVA: 0x0066A0D8 File Offset: 0x006682D8
	public BP_MediaDissolveManagea_C SpawnOrGetVideoBp()
	{
		if (this.VideoBpInternal != null)
		{
			return this.VideoBp;
		}
		FTransformDouble transform = Global.BaseCharacter.D_GetTransform();
		if (!transform.IsValid())
		{
			return null;
		}
		this.VideoBpInternal = (Singleton<ActorSystem>.Instance.Spawn(BP_MediaDissolveManagea_C.StaticClass(), transform, Global.BaseCharacter) as BP_MediaDissolveManagea_C);
		if (this.VideoBpInternal != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Preload, ELogAuthor.JYS, "[VideoBp]成功生成VideoBp蓝图", default(ReadOnlySpan<ValueTuple<string, object>>));
			return this.VideoBpInternal;
		}
		return null;
	}

	// Token: 0x06017269 RID: 94825 RVA: 0x0066A158 File Offset: 0x00668358
	public void RemoveVideoBp()
	{
		if (this.VideoBpInternal == null)
		{
			return;
		}
		Singleton<Log>.Instance.Info(ELogModule.Preload, ELogAuthor.JYS, "[VideoBp]成功移除VideoBp蓝图", default(ReadOnlySpan<ValueTuple<string, object>>));
		Singleton<ActorSystem>.Instance.Put("VideoBpModel", this.VideoBpInternal, null);
		this.VideoBpInternal = null;
	}

	// Token: 0x0601726A RID: 94826 RVA: 0x0066A1A8 File Offset: 0x006683A8
	public void RemoveOnVideoEnd()
	{
		this.RemoveVideoBp();
		this.ClearPreloadMap();
	}

	// Token: 0x0601726B RID: 94827 RVA: 0x0066A1B6 File Offset: 0x006683B6
	public void RemovePreload()
	{
		this.ClearPreloadMap();
	}

	// Token: 0x0400B20E RID: 45582
	[Nullable(1)]
	private readonly Dictionary<string, UMediaSource> VideoPreloadMap = new Dictionary<string, UMediaSource>();

	// Token: 0x0400B20F RID: 45583
	private BP_MediaDissolveManagea_C VideoBpInternal;
}
