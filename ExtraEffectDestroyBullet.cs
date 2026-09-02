using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F27 RID: 12071
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectDestroyBullet : BuffEffect
{
	// Token: 0x06018B70 RID: 101232 RVA: 0x006FB457 File Offset: 0x006F9657
	public ExtraEffectDestroyBullet(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B71 RID: 101233 RVA: 0x006FB466 File Offset: 0x006F9666
	protected override bool CheckExecutable()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018B72 RID: 101234 RVA: 0x006FB47C File Offset: 0x006F967C
	protected unsafe override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.HCW;
			string message = "销毁子弹额外效果参数为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Buff", this.BuffId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		int num2;
		int num = int.TryParse((extraEffectParameters_.Length != 0) ? extraEffectParameters_[0] : string.Empty, out num2) ? num2 : 0;
		if (num == 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Battle;
			ELogAuthor author2 = ELogAuthor.HCW;
			string message2 = "第一个参数错误";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Buff", this.BuffId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Param", num);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		string text = (extraEffectParameters_.Length > 1) ? extraEffectParameters_[1] : string.Empty;
		if (string.IsNullOrEmpty(text))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Battle;
			ELogAuthor author3 = ELogAuthor.HCW;
			string message3 = "第二个参数为空";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Buff", this.BuffId);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		this.BulletOwner = (EBulletOwner)num;
		this.BulletRowNames = text.Split('#', StringSplitOptions.None);
		string text2 = (extraEffectParameters_.Length > 2) ? extraEffectParameters_[2] : string.Empty;
		if (!string.IsNullOrEmpty(text2))
		{
			this.SummonChildBullet = (int.Parse(text2) == 1);
		}
		string text3 = (extraEffectParameters_.Length > 3) ? extraEffectParameters_[3] : string.Empty;
		if (!string.IsNullOrEmpty(text3))
		{
			float num3 = float.Parse(text3);
			this.RadiusSquared = num3 * num3;
		}
		string text4 = (extraEffectParameters_.Length > 4) ? extraEffectParameters_[4] : string.Empty;
		if (!string.IsNullOrEmpty(text4))
		{
			this.RangeTargetType = (EDestroyRangeTargetType)int.Parse(text4);
		}
	}

	// Token: 0x06018B73 RID: 101235 RVA: 0x006FB62A File Offset: 0x006F982A
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018B74 RID: 101236 RVA: 0x006FB630 File Offset: 0x006F9830
	public override void OnRemoved(bool bPremature)
	{
		if (this.BulletOwner == EBulletOwner.None || this.BulletRowNames == null)
		{
			return;
		}
		Entity entity;
		if (this.BulletOwner != EBulletOwner.Instigator)
		{
			entity = base.OwnerEntity;
		}
		else
		{
			EntityHandle instigatorEntity = base.InstigatorEntity;
			entity = ((instigatorEntity != null) ? instigatorEntity.Entity : null);
		}
		Entity entity2 = entity;
		int? num = (entity2 != null) ? new int?(entity2.Id) : null;
		if (num == null)
		{
			return;
		}
		BulletModel instance = ModelBase<BulletModel>.Instance;
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = instance.GetBulletSetByAttacker(num.Value);
		if (bulletSetByAttacker == null)
		{
			return;
		}
		Vector vector;
		if (this.RangeTargetType != EDestroyRangeTargetType.BulletOwner)
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				vector = null;
			}
			else
			{
				WorldEntity entity3 = getCurrentEntity.Entity;
				if (entity3 == null)
				{
					vector = null;
				}
				else
				{
					BaseActorComponent component = entity3.GetComponent<BaseActorComponent>();
					vector = ((component != null) ? component.ActorLocationProxy : null);
				}
			}
		}
		else if (entity2 == null)
		{
			vector = null;
		}
		else
		{
			BaseActorComponent component2 = entity2.GetComponent<BaseActorComponent>();
			vector = ((component2 != null) ? component2.ActorLocationProxy : null);
		}
		Vector vector2 = vector;
		List<int> list = new List<int>();
		if (this.RadiusSquared <= 0f || vector2 == null)
		{
			foreach (BulletEntity bulletEntity in bulletSetByAttacker)
			{
				if (bulletEntity != null && bulletEntity.Valid)
				{
					string bulletRowName = bulletEntity.GetBulletInfo().BulletRowName;
					bool flag = false;
					for (int i = 0; i < this.BulletRowNames.Length; i++)
					{
						if (this.BulletRowNames[i] == bulletRowName)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						list.Add(bulletEntity.Id);
					}
				}
			}
			foreach (int id in list)
			{
				instance.DestroyBullet(id, this.SummonChildBullet, EBulletDestroyReason.BuffEffect, false);
			}
			return;
		}
		foreach (BulletEntity bulletEntity2 in bulletSetByAttacker)
		{
			if (bulletEntity2 != null && bulletEntity2.Valid)
			{
				string bulletRowName2 = bulletEntity2.GetBulletInfo().BulletRowName;
				bool flag2 = false;
				for (int j = 0; j < this.BulletRowNames.Length; j++)
				{
					if (this.BulletRowNames[j] == bulletRowName2)
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					BaseActorComponent component3 = bulletEntity2.GetComponent<BaseActorComponent>();
					Vector vector3 = (component3 != null) ? component3.ActorLocationProxy : null;
					if (vector3 != null && Vector.DistSquared(vector3, vector2) <= (double)this.RadiusSquared)
					{
						list.Add(bulletEntity2.Id);
					}
				}
			}
		}
		foreach (int id2 in list)
		{
			instance.DestroyBullet(id2, this.SummonChildBullet, EBulletDestroyReason.BuffEffect, false);
		}
	}

	// Token: 0x0400C081 RID: 49281
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private string[] BulletRowNames;

	// Token: 0x0400C082 RID: 49282
	private EBulletOwner BulletOwner;

	// Token: 0x0400C083 RID: 49283
	private bool SummonChildBullet;

	// Token: 0x0400C084 RID: 49284
	private EDestroyRangeTargetType RangeTargetType;

	// Token: 0x0400C085 RID: 49285
	private float RadiusSquared;
}
