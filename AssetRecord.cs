using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020032A6 RID: 12966
[NullableContext(1)]
[Nullable(0)]
public class AssetRecord : IDbAssetElement
{
	// Token: 0x170024FD RID: 9469
	// (get) Token: 0x0601B2F9 RID: 111353 RVA: 0x0082BF56 File Offset: 0x0082A156
	// (set) Token: 0x0601B2FA RID: 111354 RVA: 0x0082BF5E File Offset: 0x0082A15E
	public HashSet<string> AssetSet { get; set; } = new HashSet<string>();

	// Token: 0x170024FE RID: 9470
	// (get) Token: 0x0601B2FB RID: 111355 RVA: 0x0082BF67 File Offset: 0x0082A167
	// (set) Token: 0x0601B2FC RID: 111356 RVA: 0x0082BF6F File Offset: 0x0082A16F
	public List<string> ActorClass { get; set; } = new List<string>();

	// Token: 0x170024FF RID: 9471
	// (get) Token: 0x0601B2FD RID: 111357 RVA: 0x0082BF78 File Offset: 0x0082A178
	// (set) Token: 0x0601B2FE RID: 111358 RVA: 0x0082BF80 File Offset: 0x0082A180
	public List<string> Animations { get; set; } = new List<string>();

	// Token: 0x17002500 RID: 9472
	// (get) Token: 0x0601B2FF RID: 111359 RVA: 0x0082BF89 File Offset: 0x0082A189
	// (set) Token: 0x0601B300 RID: 111360 RVA: 0x0082BF91 File Offset: 0x0082A191
	public List<string> Effects { get; set; } = new List<string>();

	// Token: 0x17002501 RID: 9473
	// (get) Token: 0x0601B301 RID: 111361 RVA: 0x0082BF9A File Offset: 0x0082A19A
	// (set) Token: 0x0601B302 RID: 111362 RVA: 0x0082BFA2 File Offset: 0x0082A1A2
	public List<string> Audios { get; set; } = new List<string>();

	// Token: 0x17002502 RID: 9474
	// (get) Token: 0x0601B303 RID: 111363 RVA: 0x0082BFAB File Offset: 0x0082A1AB
	// (set) Token: 0x0601B304 RID: 111364 RVA: 0x0082BFB3 File Offset: 0x0082A1B3
	public List<string> Meshes { get; set; } = new List<string>();

	// Token: 0x17002503 RID: 9475
	// (get) Token: 0x0601B305 RID: 111365 RVA: 0x0082BFBC File Offset: 0x0082A1BC
	// (set) Token: 0x0601B306 RID: 111366 RVA: 0x0082BFC4 File Offset: 0x0082A1C4
	public List<string> Materials { get; set; } = new List<string>();

	// Token: 0x17002504 RID: 9476
	// (get) Token: 0x0601B307 RID: 111367 RVA: 0x0082BFCD File Offset: 0x0082A1CD
	// (set) Token: 0x0601B308 RID: 111368 RVA: 0x0082BFD5 File Offset: 0x0082A1D5
	public List<string> AnimationBlueprints { get; set; } = new List<string>();

	// Token: 0x17002505 RID: 9477
	// (get) Token: 0x0601B309 RID: 111369 RVA: 0x0082BFDE File Offset: 0x0082A1DE
	// (set) Token: 0x0601B30A RID: 111370 RVA: 0x0082BFE6 File Offset: 0x0082A1E6
	public List<string> Others { get; set; } = new List<string>();

	// Token: 0x0601B30B RID: 111371 RVA: 0x0082BFEF File Offset: 0x0082A1EF
	public bool AddActorClass(string path)
	{
		if (!this.AddAsset(path))
		{
			return false;
		}
		this.ActorClass.Add(path);
		return true;
	}

	// Token: 0x0601B30C RID: 111372 RVA: 0x0082C009 File Offset: 0x0082A209
	public void AddAnimation(string path)
	{
		if (!this.AddAsset(path))
		{
			return;
		}
		this.Animations.Add(path);
	}

	// Token: 0x0601B30D RID: 111373 RVA: 0x0082C024 File Offset: 0x0082A224
	[NullableContext(0)]
	public ValueTuple<bool, bool> TryAddEffect([Nullable(1)] string path)
	{
		string path2 = path;
		if (path.Contains("GA_"))
		{
			path2 = path + "_C";
		}
		return new ValueTuple<bool, bool>(this.AddOther(path2), false);
	}

	// Token: 0x0601B30E RID: 111374 RVA: 0x0082C059 File Offset: 0x0082A259
	public bool AddEffect(string path)
	{
		if (!this.AddAsset(path))
		{
			return false;
		}
		this.Effects.Add(path);
		return true;
	}

	// Token: 0x0601B30F RID: 111375 RVA: 0x0082C073 File Offset: 0x0082A273
	public void AddAudio(string path)
	{
		if (!this.AddAsset(path))
		{
			return;
		}
		this.Audios.Add(path);
	}

	// Token: 0x0601B310 RID: 111376 RVA: 0x0082C08B File Offset: 0x0082A28B
	public void AddMesh(string path)
	{
		if (!this.AddAsset(path))
		{
			return;
		}
		this.Meshes.Add(path);
	}

	// Token: 0x0601B311 RID: 111377 RVA: 0x0082C0A3 File Offset: 0x0082A2A3
	public void AddMaterial(string path)
	{
		if (!this.AddAsset(path))
		{
			return;
		}
		this.Materials.Add(path);
	}

	// Token: 0x0601B312 RID: 111378 RVA: 0x0082C0BB File Offset: 0x0082A2BB
	public void AddAnimationBlueprint(string path)
	{
		if (!this.AddAsset(path))
		{
			return;
		}
		this.AnimationBlueprints.Add(path);
	}

	// Token: 0x0601B313 RID: 111379 RVA: 0x0082C0D3 File Offset: 0x0082A2D3
	public bool AddOther(string path)
	{
		if (!this.AddAsset(path))
		{
			return false;
		}
		this.Others.Add(path);
		return true;
	}

	// Token: 0x0601B314 RID: 111380 RVA: 0x0082C0F0 File Offset: 0x0082A2F0
	private bool AddAsset(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return false;
		}
		if (path.StartsWith("/Game/Aki/Scene/Assets/Temp"))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Preload;
			ELogAuthor author = ELogAuthor.LFJW;
			string message = "[预加载] 不能搜集该目录的资源";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Path", path);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return this.AssetSet.Add(path);
	}

	// Token: 0x0601B315 RID: 111381 RVA: 0x0082C150 File Offset: 0x0082A350
	public bool Copy(AssetRecord other)
	{
		foreach (string path in other.ActorClass)
		{
			this.AddActorClass(path);
		}
		foreach (string path2 in other.Animations)
		{
			this.AddAnimation(path2);
		}
		foreach (string path3 in other.Effects)
		{
			this.AddEffect(path3);
		}
		foreach (string path4 in other.Audios)
		{
			this.AddAudio(path4);
		}
		foreach (string path5 in other.Meshes)
		{
			this.AddMesh(path5);
		}
		foreach (string path6 in other.Materials)
		{
			this.AddMaterial(path6);
		}
		foreach (string path7 in other.AnimationBlueprints)
		{
			this.AddAnimationBlueprint(path7);
		}
		foreach (string path8 in other.Others)
		{
			this.AddOther(path8);
		}
		return true;
	}
}
