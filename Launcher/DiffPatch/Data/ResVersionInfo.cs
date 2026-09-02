using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Util;

namespace CSharpScript.Launcher.DiffPatch.Data
{
	// Token: 0x0200464E RID: 17998
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class ResVersionInfo
	{
		// Token: 0x0602EF80 RID: 192384 RVA: 0x00B2115C File Offset: 0x00B1F35C
		public ResVersionInfo(string packageVersion, string remoteVersion, Dictionary<string, string> remoteManifestHashMap)
		{
			this.PackageVersion = packageVersion;
			this.RemoteVersion = remoteVersion;
			this.RemoteManifestHashMap = remoteManifestHashMap;
		}

		// Token: 0x0602EF81 RID: 192385 RVA: 0x00B211AC File Offset: 0x00B1F3AC
		public unsafe virtual void Init()
		{
			this.VersionRecord = Singleton<LauncherStorageLib>.Instance.GetDeviceSavedString(this.GetVersionRecordKey(), "");
			VersionInfo item = VersionInfo.TryParse(this.PackageVersion).Item2;
			VersionInfo item2 = VersionInfo.TryParse((this.VersionRecord != null && this.VersionRecord != "") ? this.VersionRecord : this.PackageVersion).Item2;
			VersionInfo item3 = VersionInfo.TryParse(this.RemoteVersion).Item2;
			this.MountOrder = item3.Patch + 4;
			this.NeedRevert = !VersionInfo.LessThanOrEqual(item2, item3);
			this.PackageVersionRecord = item2.ToString(2) + ".0";
			this.LocalCurrentVersion = (VersionInfo.PackageEquals(item, item2) ? ((this.VersionRecord != null && this.VersionRecord != "") ? this.VersionRecord : this.PackageVersion) : this.PackageVersion);
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "inited res version.";
			<>y__InlineArray7<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray7<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("record", this.VersionRecord);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("remote", this.RemoteVersion);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("recordPackage", this.PackageVersionRecord);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("package", this.PackageVersion);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("localCurPackage", this.LocalCurrentVersion);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 5) = new ValueTuple<string, object>("needRevert", this.NeedRevert);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 6) = new ValueTuple<string, object>("res", this.GetResType());
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray7<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 7));
		}

		// Token: 0x170080A4 RID: 32932
		// (get) Token: 0x0602EF82 RID: 192386 RVA: 0x00B2138C File Offset: 0x00B1F58C
		public bool NeedRevertVersion
		{
			get
			{
				return this.NeedRevert;
			}
		}

		// Token: 0x0602EF83 RID: 192387 RVA: 0x00B21394 File Offset: 0x00B1F594
		public string GetPackageVersion()
		{
			return this.PackageVersion;
		}

		// Token: 0x170080A5 RID: 32933
		// (get) Token: 0x0602EF84 RID: 192388 RVA: 0x00B2139C File Offset: 0x00B1F59C
		public string LatestVersion
		{
			get
			{
				return this.RemoteVersion;
			}
		}

		// Token: 0x170080A6 RID: 32934
		// (get) Token: 0x0602EF85 RID: 192389 RVA: 0x00B213A4 File Offset: 0x00B1F5A4
		public string CurrentVersion
		{
			get
			{
				return this.LocalCurrentVersion;
			}
		}

		// Token: 0x170080A7 RID: 32935
		// (get) Token: 0x0602EF86 RID: 192390 RVA: 0x00B213AC File Offset: 0x00B1F5AC
		public string RecordVersion
		{
			get
			{
				return this.VersionRecord;
			}
		}

		// Token: 0x170080A8 RID: 32936
		// (get) Token: 0x0602EF87 RID: 192391 RVA: 0x00B213B4 File Offset: 0x00B1F5B4
		public string RecordPackageVersion
		{
			get
			{
				return this.PackageVersionRecord;
			}
		}

		// Token: 0x0602EF88 RID: 192392 RVA: 0x00B213BC File Offset: 0x00B1F5BC
		public void SetPackageVersionRecord(string version)
		{
			this.PackageVersionRecord = version;
		}

		// Token: 0x170080A9 RID: 32937
		// (get) Token: 0x0602EF89 RID: 192393 RVA: 0x00B213C8 File Offset: 0x00B1F5C8
		public virtual string ManifestHash
		{
			get
			{
				string text;
				this.RemoteManifestHashMap.TryGetValue(this.RemoteVersion, out text);
				if (text == null)
				{
					return "";
				}
				return text;
			}
		}

		// Token: 0x170080AA RID: 32938
		// (get) Token: 0x0602EF8A RID: 192394 RVA: 0x00B213F4 File Offset: 0x00B1F5F4
		public string RevertManifestHash
		{
			get
			{
				string text;
				this.RemoteManifestHashMap.TryGetValue(this.RecordVersion, out text);
				if (text == null)
				{
					return "";
				}
				return text;
			}
		}

		// Token: 0x0602EF8B RID: 192395 RVA: 0x00B2141F File Offset: 0x00B1F61F
		public string GetMountFileName()
		{
			return "Mount" + this.GetResType() + ".txt";
		}

		// Token: 0x0602EF8C RID: 192396 RVA: 0x00B21436 File Offset: 0x00B1F636
		public virtual string GetManifestFileName()
		{
			return "Manifest" + this.GetResType();
		}

		// Token: 0x0602EF8D RID: 192397 RVA: 0x00B21448 File Offset: 0x00B1F648
		protected virtual string GetVersionRecordKey()
		{
			return "Version_" + this.GetResType();
		}

		// Token: 0x0602EF8E RID: 192398 RVA: 0x00B2145A File Offset: 0x00B1F65A
		public virtual bool HasContentOnRemote()
		{
			return this.PackageVersion != this.RemoteVersion || this.ManifestHash.Length > 0;
		}

		// Token: 0x0602EF8F RID: 192399 RVA: 0x00B21480 File Offset: 0x00B1F680
		public unsafe virtual bool UpdateVersionRecord()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "update res version.";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("res", this.GetResType());
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ver", this.RemoteVersion);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (!Singleton<LauncherStorageLib>.Instance.SetDeviceSavedString(this.GetVersionRecordKey(), this.RemoteVersion))
			{
				return false;
			}
			this.VersionRecord = this.RemoteVersion;
			if (!this.RecordUse(true))
			{
				return false;
			}
			this.Init();
			return true;
		}

		// Token: 0x0602EF90 RID: 192400 RVA: 0x00B2151E File Offset: 0x00B1F71E
		public virtual bool RecordUse(bool bUse)
		{
			return true;
		}

		// Token: 0x0602EF91 RID: 192401 RVA: 0x00B21521 File Offset: 0x00B1F721
		public int GetMountOrder()
		{
			return this.MountOrder;
		}

		// Token: 0x0602EF92 RID: 192402 RVA: 0x00B2152C File Offset: 0x00B1F72C
		public virtual bool ClearVersionRecord()
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "clear res version.";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("res", this.GetResType());
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			if (!Singleton<LauncherStorageLib>.Instance.DeleteDeviceSavedString(this.GetVersionRecordKey()))
			{
				return false;
			}
			if (this.GetResType() == EResType.Launcher.ToEnumString() && !Singleton<LauncherStorageLib>.Instance.DeleteDeviceSavedString("__kr_blvr__"))
			{
				return false;
			}
			if (!this.ClearUseRecord())
			{
				return false;
			}
			this.Init();
			return true;
		}

		// Token: 0x0602EF93 RID: 192403 RVA: 0x00B215AC File Offset: 0x00B1F7AC
		protected virtual bool ClearUseRecord()
		{
			return true;
		}

		// Token: 0x0602EF94 RID: 192404 RVA: 0x00B215AF File Offset: 0x00B1F7AF
		public virtual bool IsLangRes()
		{
			return false;
		}

		// Token: 0x0602EF95 RID: 192405 RVA: 0x00B215B2 File Offset: 0x00B1F7B2
		public virtual void ForceUpdate()
		{
		}

		// Token: 0x0602EF96 RID: 192406 RVA: 0x00B215B4 File Offset: 0x00B1F7B4
		public virtual bool SkipUpdate()
		{
			return false;
		}

		// Token: 0x0602EF97 RID: 192407 RVA: 0x00B215B7 File Offset: 0x00B1F7B7
		public virtual bool NeedRecordMount()
		{
			return true;
		}

		// Token: 0x0602EF98 RID: 192408
		public abstract string GetResType();

		// Token: 0x0401ABC2 RID: 109506
		protected string VersionRecord = "";

		// Token: 0x0401ABC3 RID: 109507
		protected string PackageVersionRecord = "";

		// Token: 0x0401ABC4 RID: 109508
		protected string LocalCurrentVersion = "";

		// Token: 0x0401ABC5 RID: 109509
		protected bool NeedRevert;

		// Token: 0x0401ABC6 RID: 109510
		private int MountOrder = 4;

		// Token: 0x0401ABC7 RID: 109511
		protected readonly string PackageVersion;

		// Token: 0x0401ABC8 RID: 109512
		protected readonly string RemoteVersion;

		// Token: 0x0401ABC9 RID: 109513
		protected readonly Dictionary<string, string> RemoteManifestHashMap;
	}
}
