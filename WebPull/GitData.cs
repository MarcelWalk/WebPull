using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebPull
{
    public partial class GitData
    {
        [JsonProperty("hook_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? HookId { get; set; }

        [JsonProperty("hook", NullValueHandling = NullValueHandling.Ignore)]
        public Hook Hook { get; set; }

        [JsonProperty("repository", NullValueHandling = NullValueHandling.Ignore)]
        public Repository Repository { get; set; }

        [JsonProperty("sender", NullValueHandling = NullValueHandling.Ignore)]
        public Sender Sender { get; set; }
    }

    public partial class Hook
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Events { get; set; }

        [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
        public Config Config { get; set; }

        [JsonProperty("last_response", NullValueHandling = NullValueHandling.Ignore)]
        public LastResponse LastResponse { get; set; }
    }

    public partial class Config
    {
        [JsonProperty("content_type", NullValueHandling = NullValueHandling.Ignore)]
        public string ContentType { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }
    }

    public partial class LastResponse
    {
        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }
    }

    public partial class Repository
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("node_id", NullValueHandling = NullValueHandling.Ignore)]
        public string NodeId { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("full_name", NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }

        [JsonProperty("private", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Private { get; set; }

        [JsonProperty("owner", NullValueHandling = NullValueHandling.Ignore)]
        public Sender Owner { get; set; }

        [JsonProperty("html_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("fork", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Fork { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("clone_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri CloneUrl { get; set; }

        [JsonProperty("svn_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri SvnUrl { get; set; }

        [JsonProperty("homepage")]
        public object Homepage { get; set; }

        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public long? Size { get; set; }

        [JsonProperty("stargazers_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? StargazersCount { get; set; }

        [JsonProperty("watchers_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? WatchersCount { get; set; }

        [JsonProperty("language")]
        public object Language { get; set; }

        [JsonProperty("has_issues", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasIssues { get; set; }

        [JsonProperty("has_projects", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasProjects { get; set; }

        [JsonProperty("has_downloads", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasDownloads { get; set; }

        [JsonProperty("has_wiki", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasWiki { get; set; }

        [JsonProperty("has_pages", NullValueHandling = NullValueHandling.Ignore)]
        public bool? HasPages { get; set; }

        [JsonProperty("forks_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? ForksCount { get; set; }

        [JsonProperty("mirror_url")]
        public object MirrorUrl { get; set; }

        [JsonProperty("archived", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Archived { get; set; }

        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty("open_issues_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? OpenIssuesCount { get; set; }

        [JsonProperty("license")]
        public object License { get; set; }

        [JsonProperty("forks", NullValueHandling = NullValueHandling.Ignore)]
        public long? Forks { get; set; }

        [JsonProperty("open_issues", NullValueHandling = NullValueHandling.Ignore)]
        public long? OpenIssues { get; set; }

        [JsonProperty("watchers", NullValueHandling = NullValueHandling.Ignore)]
        public long? Watchers { get; set; }

        [JsonProperty("default_branch", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultBranch { get; set; }
    }

    public partial class Sender
    {
        [JsonProperty("login", NullValueHandling = NullValueHandling.Ignore)]
        public string Login { get; set; }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("node_id", NullValueHandling = NullValueHandling.Ignore)]
        public string NodeId { get; set; }

        [JsonProperty("avatar_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("gravatar_id", NullValueHandling = NullValueHandling.Ignore)]
        public string GravatarId { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("html_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri HtmlUrl { get; set; }

        [JsonProperty("followers_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri FollowersUrl { get; set; }

        [JsonProperty("following_url", NullValueHandling = NullValueHandling.Ignore)]
        public string FollowingUrl { get; set; }

        [JsonProperty("gists_url", NullValueHandling = NullValueHandling.Ignore)]
        public string GistsUrl { get; set; }

        [JsonProperty("starred_url", NullValueHandling = NullValueHandling.Ignore)]
        public string StarredUrl { get; set; }

        [JsonProperty("subscriptions_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri SubscriptionsUrl { get; set; }

        [JsonProperty("organizations_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri OrganizationsUrl { get; set; }

        [JsonProperty("repos_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ReposUrl { get; set; }

        [JsonProperty("events_url", NullValueHandling = NullValueHandling.Ignore)]
        public string EventsUrl { get; set; }

        [JsonProperty("received_events_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ReceivedEventsUrl { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("site_admin", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SiteAdmin { get; set; }
    }
}
