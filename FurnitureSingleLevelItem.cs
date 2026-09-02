using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001073 RID: 4211
public class FurnitureSingleLevelItem : FurnitureSceneItemBase
{
	// Token: 0x06006D9F RID: 28063 RVA: 0x001C8182 File Offset: 0x001C6382
	public FurnitureSingleLevelItem(int furnitureConfigId) : base(furnitureConfigId)
	{
		this.SceneItemType = EFurnitureSceneItemType.SingleLevel;
	}

	// Token: 0x06006DA0 RID: 28064 RVA: 0x001C8194 File Offset: 0x001C6394
	protected override UniTask<bool> LoadAsyncImplement([Nullable(1)] Transform rootTransform)
	{
		FurnitureSingleLevelItem.<LoadAsyncImplement>d__2 <LoadAsyncImplement>d__;
		<LoadAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadAsyncImplement>d__.<>4__this = this;
		<LoadAsyncImplement>d__.rootTransform = rootTransform;
		<LoadAsyncImplement>d__.<>1__state = -1;
		<LoadAsyncImplement>d__.<>t__builder.Start<FurnitureSingleLevelItem.<LoadAsyncImplement>d__2>(ref <LoadAsyncImplement>d__);
		return <LoadAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06006DA1 RID: 28065 RVA: 0x001C81DF File Offset: 0x001C63DF
	protected override void ShowImplement()
	{
		if (this.LevelContext == null)
		{
			return;
		}
		base.ShowLevelInstance(this.LevelContext);
	}

	// Token: 0x06006DA2 RID: 28066 RVA: 0x001C81F6 File Offset: 0x001C63F6
	protected override void HideImplement()
	{
		if (this.LevelContext == null)
		{
			return;
		}
		base.HideLevelInstance(this.LevelContext);
	}

	// Token: 0x06006DA3 RID: 28067 RVA: 0x001C820D File Offset: 0x001C640D
	protected override void UnloadImplement()
	{
		if (this.LevelContext != null)
		{
			base.UnloadLevelInstance(this.LevelContext);
			this.LevelContext = null;
		}
	}

	// Token: 0x040033F5 RID: 13301
	[Nullable(2)]
	private FurnitureLevelContext LevelContext;
}
