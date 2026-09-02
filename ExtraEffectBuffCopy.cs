using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F16 RID: 12054
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectBuffCopy : BuffEffect
{
	// Token: 0x06018B1E RID: 101150 RVA: 0x006F8A37 File Offset: 0x006F6C37
	public ExtraEffectBuffCopy(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B1F RID: 101151 RVA: 0x006F8A5C File Offset: 0x006F6C5C
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		this.BuffIds = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.BuffIds[i] = long.Parse(array[i]);
		}
		this.BulletId = long.Parse(extraEffectParameters_[1]);
	}

	// Token: 0x06018B20 RID: 101152 RVA: 0x006F8AB8 File Offset: 0x006F6CB8
	protected void AddEvent()
	{
		Entity ownerEntity = base.OwnerEntity;
		if (ownerEntity == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.TZQ;
			string message = "buff监听实体不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("BuffId", this.BuffId);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (!Singleton<EventSystem>.Instance.HasWithTarget(ownerEntity, EEventName.CharHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<HitInformation, HitContext>(ownerEntity, EEventName.CharHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal));
		}
		if (!Singleton<EventSystem>.Instance.HasWithTarget(ownerEntity, EEventName.CharHitRemote, new Action<HitContext>(this.OnHitRemote)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<HitContext>(ownerEntity, EEventName.CharHitRemote, new Action<HitContext>(this.OnHitRemote));
		}
	}

	// Token: 0x06018B21 RID: 101153 RVA: 0x006F8B6A File Offset: 0x006F6D6A
	public override void OnCreated()
	{
		this.EntityIds.Clear();
		this.AddEvent();
	}

	// Token: 0x06018B22 RID: 101154 RVA: 0x006F8B7D File Offset: 0x006F6D7D
	protected void OnHitLocal(HitInformation hitData, HitContext hitContext)
	{
		this.RecordHit(hitContext);
	}

	// Token: 0x06018B23 RID: 101155 RVA: 0x006F8B86 File Offset: 0x006F6D86
	protected void OnHitRemote(HitContext hitContext)
	{
		this.RecordHit(hitContext);
	}

	// Token: 0x06018B24 RID: 101156 RVA: 0x006F8B8F File Offset: 0x006F6D8F
	protected void RecordHit(HitContext hitContext)
	{
		if (hitContext.BulletId == this.BulletId)
		{
			this.EntityIds.Add(hitContext.Target.Id);
		}
	}

	// Token: 0x06018B25 RID: 101157 RVA: 0x006F8BB8 File Offset: 0x006F6DB8
	protected void CopyBuff(long buffId, BaseBuffComponent[] buffCompList, int[] buffStack)
	{
		int num = 0;
		for (int i = 0; i < buffCompList.Length; i++)
		{
			int buffTotalStackById = buffCompList[i].GetBuffTotalStackById(buffId, false);
			buffStack[i] = buffTotalStackById;
			num = Math.Max(buffTotalStackById, num);
		}
		if (num == 0)
		{
			return;
		}
		for (int j = 0; j < buffCompList.Length; j++)
		{
			int num2 = num - buffStack[j];
			if (num2 > 0)
			{
				buffCompList[j].AddIterativeBuff(buffId, base.PendingBuff, new int?(num2), true, "buff的额外效果:复制buff", null, null);
			}
		}
	}

	// Token: 0x06018B26 RID: 101158 RVA: 0x006F8C34 File Offset: 0x006F6E34
	protected void RemoveEvent()
	{
		Entity ownerEntity = base.OwnerEntity;
		if (ownerEntity != null)
		{
			if (Singleton<EventSystem>.Instance.HasWithTarget(ownerEntity, EEventName.CharHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(ownerEntity, EEventName.CharHitLocal, new Action<HitInformation, HitContext>(this.OnHitLocal));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(ownerEntity, EEventName.CharHitRemote, new Action<HitContext>(this.OnHitRemote)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(ownerEntity, EEventName.CharHitRemote, new Action<HitContext>(this.OnHitRemote));
			}
		}
	}

	// Token: 0x06018B27 RID: 101159 RVA: 0x006F8CB8 File Offset: 0x006F6EB8
	public override void OnRemoved(bool bPremature)
	{
		this.RemoveEvent();
		List<BaseBuffComponent> list = new List<BaseBuffComponent>();
		foreach (int id in this.EntityIds)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(id);
			BaseBuffComponent baseBuffComponent = (entity != null) ? entity.GetComponent<BaseBuffComponent>() : null;
			if (baseBuffComponent != null)
			{
				list.Add(baseBuffComponent);
			}
		}
		int[] buffStack = new int[list.Count];
		foreach (long buffId in this.BuffIds)
		{
			this.CopyBuff(buffId, list.ToArray(), buffStack);
		}
	}

	// Token: 0x06018B28 RID: 101160 RVA: 0x006F8D74 File Offset: 0x006F6F74
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018B29 RID: 101161 RVA: 0x006F8D78 File Offset: 0x006F6F78
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(57, 2);
		defaultInterpolatedStringHandler.AppendLiteral("获取buff持续时间内buff持有者的子弹");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BulletId);
		defaultInterpolatedStringHandler.AppendLiteral("命中的所有目标,在buff结束时将buff");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<long>(",", this.BuffIds));
		defaultInterpolatedStringHandler.AppendLiteral("的最高层数复制给其余命中的敌人");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C03F RID: 49215
	protected long[] BuffIds = Array.Empty<long>();

	// Token: 0x0400C040 RID: 49216
	protected long BulletId;

	// Token: 0x0400C041 RID: 49217
	protected HashSet<int> EntityIds = new HashSet<int>();
}
