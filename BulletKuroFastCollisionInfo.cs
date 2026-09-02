using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E06 RID: 11782
[NullableContext(2)]
[Nullable(0)]
public class BulletKuroFastCollisionInfo
{
	// Token: 0x06017CCB RID: 97483 RVA: 0x006A239C File Offset: 0x006A059C
	[NullableContext(1)]
	public unsafe void RegisterCollision(BulletInfo bulletInfo, UKuroFastCollisionAlgorithm algorithm)
	{
		this.UnregisterCollision();
		if (bulletInfo.CollisionInfo.CollisionComponent == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Bullet;
			ELogAuthor author = ELogAuthor.CFT;
			string message = "BulletKuroFastCollisionInfo只支持CollisionComponent";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("BulletEntityId", bulletInfo.BulletEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("BulletRowName", bulletInfo.BulletRowName);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		UShapeComponent ushapeComponent = bulletInfo.CollisionInfo.CollisionComponent as UShapeComponent;
		if (ushapeComponent == null)
		{
			return;
		}
		algorithm.Add(ushapeComponent);
		this.RegisteredShape = ushapeComponent;
		AActor actor = bulletInfo.Actor;
		UWorldBulletComponent uworldBulletComponent = actor.GetComponentByClass(UWorldBulletComponent.StaticClass()) as UWorldBulletComponent;
		if (uworldBulletComponent == null)
		{
			uworldBulletComponent = (actor.AddComponentByClass(UWorldBulletComponent.StaticClass(), false, Singleton<MathUtils>.Instance.DefaultTransform, false, default(FName)) as UWorldBulletComponent);
		}
		if (uworldBulletComponent == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Bullet;
			ELogAuthor author2 = ELogAuthor.CFT;
			string message2 = "BulletKuroFastCollisionInfo创建WorldBulletComponent失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("BulletEntityId", bulletInfo.BulletEntityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("BulletRowName", bulletInfo.BulletRowName);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		uworldBulletComponent.bEnable = true;
		uworldBulletComponent.WorldBulletType = (EWorldBulletType)bulletInfo.BulletDataMain.Logic.Type;
		this.WorldBulletComponent = uworldBulletComponent;
	}

	// Token: 0x06017CCC RID: 97484 RVA: 0x006A251C File Offset: 0x006A071C
	public void UnregisterCollision()
	{
		if (this.RegisteredShape == null)
		{
			return;
		}
		UKuroFastCollisionAlgorithm kuroFastCollisionAlgorithm = BulletPatternComponent.GetKuroFastCollisionAlgorithm();
		if (kuroFastCollisionAlgorithm != null)
		{
			kuroFastCollisionAlgorithm.Remove(this.RegisteredShape);
		}
		this.RegisteredShape = null;
		if (this.WorldBulletComponent != null)
		{
			this.WorldBulletComponent.bEnable = false;
		}
	}

	// Token: 0x06017CCD RID: 97485 RVA: 0x006A2562 File Offset: 0x006A0762
	public void Clear()
	{
		this.UnregisterCollision();
	}

	// Token: 0x0400B870 RID: 47216
	private UShapeComponent RegisteredShape;

	// Token: 0x0400B871 RID: 47217
	private UWorldBulletComponent WorldBulletComponent;
}
