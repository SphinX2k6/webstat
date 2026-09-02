using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x0200106C RID: 4204
public class FurnitureGroupEntityItem : FurnitureSceneItemBase
{
	// Token: 0x06006D5D RID: 27997 RVA: 0x001C7817 File Offset: 0x001C5A17
	public FurnitureGroupEntityItem(int furnitureConfigId) : base(furnitureConfigId)
	{
		this.SceneItemType = EFurnitureSceneItemType.GroupEntity;
	}

	// Token: 0x06006D5E RID: 27998 RVA: 0x001C7834 File Offset: 0x001C5A34
	protected override UniTask<bool> LoadAsyncImplement([Nullable(1)] Transform rootTransform)
	{
		FurnitureGroupEntityItem.<LoadAsyncImplement>d__2 <LoadAsyncImplement>d__;
		<LoadAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadAsyncImplement>d__.<>4__this = this;
		<LoadAsyncImplement>d__.rootTransform = rootTransform;
		<LoadAsyncImplement>d__.<>1__state = -1;
		<LoadAsyncImplement>d__.<>t__builder.Start<FurnitureGroupEntityItem.<LoadAsyncImplement>d__2>(ref <LoadAsyncImplement>d__);
		return <LoadAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06006D5F RID: 27999 RVA: 0x001C7880 File Offset: 0x001C5A80
	protected override void ShowImplement()
	{
		for (int i = 0; i < this.LevelContextList.Count; i++)
		{
			FurnitureLevelContext context = this.LevelContextList[i];
			base.ShowLevelInstance(context);
		}
	}

	// Token: 0x06006D60 RID: 28000 RVA: 0x001C78B8 File Offset: 0x001C5AB8
	protected override void HideImplement()
	{
		for (int i = 0; i < this.LevelContextList.Count; i++)
		{
			FurnitureLevelContext context = this.LevelContextList[i];
			base.HideLevelInstance(context);
		}
	}

	// Token: 0x06006D61 RID: 28001 RVA: 0x001C78F0 File Offset: 0x001C5AF0
	protected override void UnloadImplement()
	{
		for (int i = 0; i < this.LevelContextList.Count; i++)
		{
			FurnitureLevelContext context = this.LevelContextList[i];
			base.UnloadLevelInstance(context);
		}
		this.LevelContextList.Clear();
	}

	// Token: 0x040033E5 RID: 13285
	[Nullable(1)]
	private readonly List<FurnitureLevelContext> LevelContextList = new List<FurnitureLevelContext>();
}
