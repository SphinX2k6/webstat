using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001072 RID: 4210
public class FurnitureSingleEntityItem : FurnitureSceneItemBase
{
	// Token: 0x06006D9A RID: 28058 RVA: 0x001C80DA File Offset: 0x001C62DA
	public FurnitureSingleEntityItem(int furnitureConfigId) : base(furnitureConfigId)
	{
		this.SceneItemType = EFurnitureSceneItemType.SingleEntity;
	}

	// Token: 0x06006D9B RID: 28059 RVA: 0x001C80EC File Offset: 0x001C62EC
	protected override UniTask<bool> LoadAsyncImplement([Nullable(1)] Transform rootTransform)
	{
		FurnitureSingleEntityItem.<LoadAsyncImplement>d__2 <LoadAsyncImplement>d__;
		<LoadAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<LoadAsyncImplement>d__.<>4__this = this;
		<LoadAsyncImplement>d__.rootTransform = rootTransform;
		<LoadAsyncImplement>d__.<>1__state = -1;
		<LoadAsyncImplement>d__.<>t__builder.Start<FurnitureSingleEntityItem.<LoadAsyncImplement>d__2>(ref <LoadAsyncImplement>d__);
		return <LoadAsyncImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06006D9C RID: 28060 RVA: 0x001C8137 File Offset: 0x001C6337
	protected override void ShowImplement()
	{
		if (this.LevelContext == null)
		{
			return;
		}
		base.ShowLevelInstance(this.LevelContext);
	}

	// Token: 0x06006D9D RID: 28061 RVA: 0x001C814E File Offset: 0x001C634E
	protected override void HideImplement()
	{
		if (this.LevelContext == null)
		{
			return;
		}
		base.HideLevelInstance(this.LevelContext);
	}

	// Token: 0x06006D9E RID: 28062 RVA: 0x001C8165 File Offset: 0x001C6365
	protected override void UnloadImplement()
	{
		if (this.LevelContext != null)
		{
			base.UnloadLevelInstance(this.LevelContext);
			this.LevelContext = null;
		}
	}

	// Token: 0x040033F4 RID: 13300
	[Nullable(2)]
	private FurnitureLevelContext LevelContext;
}
