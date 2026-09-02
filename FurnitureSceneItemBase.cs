using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200106E RID: 4206
public abstract class FurnitureSceneItemBase
{
	// Token: 0x06006D63 RID: 28003 RVA: 0x001C7948 File Offset: 0x001C5B48
	public FurnitureSceneItemBase(int furnitureConfigId)
	{
		this.FurnitureConfigId = furnitureConfigId;
	}

	// Token: 0x06006D64 RID: 28004 RVA: 0x001C7958 File Offset: 0x001C5B58
	public UniTask<bool> LoadAndShowAsync([Nullable(1)] Transform rootTransform)
	{
		FurnitureSceneItemBase.<LoadAndShowAsync>d__7 <LoadAndShowAsync>d__;
		<LoadAndShowAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadAndShowAsync>d__.<>4__this = this;
		<LoadAndShowAsync>d__.rootTransform = rootTransform;
		<LoadAndShowAsync>d__.<>1__state = -1;
		<LoadAndShowAsync>d__.<>t__builder.Start<FurnitureSceneItemBase.<LoadAndShowAsync>d__7>(ref <LoadAndShowAsync>d__);
		return <LoadAndShowAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006D65 RID: 28005 RVA: 0x001C79A4 File Offset: 0x001C5BA4
	public UniTask<bool> LoadAsync([Nullable(1)] Transform rootTransform)
	{
		FurnitureSceneItemBase.<LoadAsync>d__8 <LoadAsync>d__;
		<LoadAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadAsync>d__.<>4__this = this;
		<LoadAsync>d__.rootTransform = rootTransform;
		<LoadAsync>d__.<>1__state = -1;
		<LoadAsync>d__.<>t__builder.Start<FurnitureSceneItemBase.<LoadAsync>d__8>(ref <LoadAsync>d__);
		return <LoadAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006D66 RID: 28006
	protected abstract UniTask<bool> LoadAsyncImplement([Nullable(1)] Transform transform);

	// Token: 0x06006D67 RID: 28007 RVA: 0x001C79EF File Offset: 0x001C5BEF
	public bool Show()
	{
		if (this.State != EFurnitureSceneItemState.Loaded && this.State != EFurnitureSceneItemState.Hide)
		{
			return false;
		}
		this.ShowImplement();
		this.State = EFurnitureSceneItemState.Show;
		return true;
	}

	// Token: 0x06006D68 RID: 28008
	protected abstract void ShowImplement();

	// Token: 0x06006D69 RID: 28009 RVA: 0x001C7A13 File Offset: 0x001C5C13
	public bool Hide()
	{
		if (this.State != EFurnitureSceneItemState.Show)
		{
			return false;
		}
		this.HideImplement();
		this.State = EFurnitureSceneItemState.Hide;
		return true;
	}

	// Token: 0x06006D6A RID: 28010
	protected abstract void HideImplement();

	// Token: 0x06006D6B RID: 28011 RVA: 0x001C7A30 File Offset: 0x001C5C30
	protected UniTask<bool> LoadLevelInstanceAsync([Nullable(1)] FurnitureLevelContext context)
	{
		FurnitureSceneItemBase.<LoadLevelInstanceAsync>d__14 <LoadLevelInstanceAsync>d__;
		<LoadLevelInstanceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadLevelInstanceAsync>d__.<>4__this = this;
		<LoadLevelInstanceAsync>d__.context = context;
		<LoadLevelInstanceAsync>d__.<>1__state = -1;
		<LoadLevelInstanceAsync>d__.<>t__builder.Start<FurnitureSceneItemBase.<LoadLevelInstanceAsync>d__14>(ref <LoadLevelInstanceAsync>d__);
		return <LoadLevelInstanceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006D6C RID: 28012 RVA: 0x001C7A7C File Offset: 0x001C5C7C
	[NullableContext(1)]
	protected void UnloadLevelInstance(FurnitureLevelContext context)
	{
		ULevelStreamingDynamic levelStreamingDynamic = context.LevelStreamingDynamic;
		if (levelStreamingDynamic == null || !levelStreamingDynamic.IsValid())
		{
			return;
		}
		levelStreamingDynamic.OnLevelLoaded.Clear();
		levelStreamingDynamic.SetShouldBeLoaded(false);
		levelStreamingDynamic.SetShouldBeVisible(false);
		levelStreamingDynamic.SetIsRequestingUnloadAndRemoval(true);
		context.LevelStreamingDynamic = null;
	}

	// Token: 0x06006D6D RID: 28013 RVA: 0x001C7AC3 File Offset: 0x001C5CC3
	[NullableContext(1)]
	protected void ShowLevelInstance(FurnitureLevelContext context)
	{
		if (context.LevelStreamingDynamic != null)
		{
			context.LevelStreamingDynamic.SetShouldBeVisible(true);
		}
	}

	// Token: 0x06006D6E RID: 28014 RVA: 0x001C7AD9 File Offset: 0x001C5CD9
	[NullableContext(1)]
	protected void HideLevelInstance(FurnitureLevelContext context)
	{
		if (context.LevelStreamingDynamic != null)
		{
			context.LevelStreamingDynamic.SetShouldBeVisible(false);
		}
	}

	// Token: 0x06006D6F RID: 28015 RVA: 0x001C7AEF File Offset: 0x001C5CEF
	public void Unload()
	{
		if (this.State == EFurnitureSceneItemState.None || this.State == EFurnitureSceneItemState.Unloaded)
		{
			return;
		}
		this.UnloadImplement();
		if (this.State == EFurnitureSceneItemState.Loading)
		{
			CustomPromise<bool> loadingPromise = this.LoadingPromise;
			if (loadingPromise != null)
			{
				loadingPromise.SetResult(false);
			}
		}
		this.State = EFurnitureSceneItemState.Unloaded;
	}

	// Token: 0x06006D70 RID: 28016
	protected abstract void UnloadImplement();

	// Token: 0x06006D71 RID: 28017 RVA: 0x001C7B2B File Offset: 0x001C5D2B
	public void MarkAsNeedUnload()
	{
		this.NeedUnload = true;
	}

	// Token: 0x06006D72 RID: 28018 RVA: 0x001C7B34 File Offset: 0x001C5D34
	public bool IsNeedUnload()
	{
		return this.NeedUnload;
	}

	// Token: 0x06006D73 RID: 28019 RVA: 0x001C7B3C File Offset: 0x001C5D3C
	public bool IsLoaded()
	{
		return this.State == EFurnitureSceneItemState.Loaded;
	}

	// Token: 0x06006D74 RID: 28020 RVA: 0x001C7B47 File Offset: 0x001C5D47
	public bool IsUnloaded()
	{
		return this.State == EFurnitureSceneItemState.Unloaded;
	}

	// Token: 0x06006D75 RID: 28021 RVA: 0x001C7B52 File Offset: 0x001C5D52
	public bool IsLoading()
	{
		return this.State == EFurnitureSceneItemState.Loading;
	}

	// Token: 0x06006D76 RID: 28022 RVA: 0x001C7B5D File Offset: 0x001C5D5D
	public EFurnitureSceneItemType GetSceneItemType()
	{
		return this.SceneItemType;
	}

	// Token: 0x06006D77 RID: 28023 RVA: 0x001C7B65 File Offset: 0x001C5D65
	public bool IsEntityType()
	{
		return this.SceneItemType == EFurnitureSceneItemType.SingleEntity || this.SceneItemType == EFurnitureSceneItemType.GroupEntity;
	}

	// Token: 0x040033E9 RID: 13289
	public readonly int FurnitureConfigId;

	// Token: 0x040033EA RID: 13290
	protected EFurnitureSceneItemType SceneItemType;

	// Token: 0x040033EB RID: 13291
	[Nullable(2)]
	private CustomPromise<bool> LoadingPromise;

	// Token: 0x040033EC RID: 13292
	private EFurnitureSceneItemState State;

	// Token: 0x040033ED RID: 13293
	[Nullable(2)]
	protected Transform RootTransform;

	// Token: 0x040033EE RID: 13294
	private bool NeedUnload;
}
